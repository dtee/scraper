// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.service.aggregator;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;

import java.util.Collection;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.StringTokenizer;

import com.ten45.domain.crawler.CategoryChecksumInfo;
import com.ten45.domain.crawler.ChecksumInfo;
import com.ten45.domain.crawler.DeDupInfo;
import com.ten45.entity.Entity;
import com.ten45.entity.common.AbstractMerchant;
import com.ten45.entity.common.Audit;
import com.ten45.entity.online.OnlineProduct;
import com.ten45.entity.product.Product;
import com.ten45.entity.product.ProductCategory;
import com.ten45.entity.product.ProductCategoryImpl;
import com.ten45.session.crawler.FeedSession;

/**
 * @see com.ten45.service.aggregator.CrawlDeDupService
 */
public class CrawlDeDupServiceImpl
    extends com.ten45.service.aggregator.CrawlDeDupServiceBase
{
    private HashMap<AbstractMerchant, MerchantChecksums> merchantChecksumList;        // Each merchant have a set of checksums
    private final String[] PRODUCT_CHECKSUM = new String[] {"impressionUrl"};
    private final String[] CATEGORY_CHECKSUM =  new String[] {"url"};    
             
    /***
     * Load load checksum information from memory
     */
    protected void handleUnLoadChecksum(AbstractMerchant merchant) 
    throws java.lang.Exception
    {
        if (this.merchantChecksumList == null) {
            throw new Exception("Merchant checksum is not loaded.");        
        }
        else if (this.merchantChecksumList.containsKey(merchant)) {
          // Remove it from the list
          this.merchantChecksumList.remove(merchant);
        }
        else {
           throw new Exception("Merchant checksum is not loaded.");
        }
    }
            
    /***
     * Load checksum information from memroy.
     */
    protected void handleLoadChecksum(AbstractMerchant merchant, String productIdAttributeName)
    throws java.lang.Exception
    {       
        if (this.merchantChecksumList == null) {
            this.merchantChecksumList = new HashMap<AbstractMerchant, MerchantChecksums>();
        }
        if (this.merchantChecksumList.containsKey(merchant)) {
            // Already exists, don't reload. - or we can do force reload here - ie. refresh the checksum amp
            //merchantChecksums = this.merchantChecksumList.get(merchant);
        }
        else {
            // Add a new merchant to the list. Merchant class will load the checksum information.
            MerchantChecksums merchantChecksums = new MerchantChecksums(merchant, productIdAttributeName);
            this.merchantChecksumList.put(merchant, merchantChecksums);
        } 
    }
    
    private static List<Entity> newCategories;                // newly discovered categories
    private static List<Entity> changedCategories;            // categories with url or other fields changed
    private static List<Entity> noChangCategories;            // categories without any kind of change
    private static List<Entity> removedCategories;            // categorries that no longer exists in the new crawl
        
    /**
     * handle category dedup: We are using Category name and it's parent as identity.
     * Takes a list of category, sync it up with the category in the database.
     */
    protected DeDupInfo handleDeDupCategories(java.util.List<ProductCategory> categories)
    throws java.lang.Exception
    {
        if (categories.size() == 0) {
            return null;             // Nothing to dedup, we are done            
        }
        
        ProductCategory firstCategory = (ProductCategory) categories.get(0);
        AbstractMerchant merchant = null;
        for (Object obj: firstCategory.getMerchants()) {
            merchant = (AbstractMerchant) obj;
        }
        
        if (merchant == null) {
            throw new Exception("ProductCategory must have a merchant");
        }        
        
        // Load the existing category in the database.
        String domain = "category:" + merchant.getInternalName();
        List<ProductCategory> dbRootCategoryList = super.getClassificationManager().loadCategories(domain);
        List<ProductCategory> rootCategoryList = new LinkedList<ProductCategory>();
        
        
        //categoryChecksum = this.getProductCategoryDao().loadCategoryChecksum(domain);
                
        newCategories = new LinkedList<Entity>();
        changedCategories = new LinkedList<Entity>();
        removedCategories = new LinkedList<Entity>();
        noChangCategories = new LinkedList<Entity>();
        
        // Build the Category tree - look for root categories (category w/o parent)
        for (ProductCategory category: categories) {
            if (category.getParent() == null) {
                rootCategoryList.add(category);
            }
        }
        
        log.debug("Total Root categories in DB:     " + dbRootCategoryList.size());
        log.debug("Total Root categories in Crawl:  " + rootCategoryList.size());
        
        recursiveDeDupCategory(null, dbRootCategoryList, rootCategoryList);

        // Update dedups to database
        DeDupInfo deDupInfo = new DeDupInfo(newCategories, changedCategories, noChangCategories, removedCategories);
        
        return deDupInfo;
    }    
    
    /**
     * Recursive dedup category.
     * @param parentCategory
     */
    protected void recursiveDeDupCategory(ProductCategory parentCategory, Collection dbRootCategoryList, Collection rootCategoryList) {
        //System.out.println("=========================  Recursive Load Category ===============;");
                
        // Look for new or existing categories
        for (Object newObj: rootCategoryList) {
            ProductCategoryImpl newCategory = (ProductCategoryImpl) newObj;
            ProductCategoryImpl dbCategory = null;
            
            for (Object dbObj : dbRootCategoryList) {
                ProductCategory category = (ProductCategory) dbObj;
                
                    // Look for the existing root category name
                if (category.getDisplayName().equals(newCategory.getDisplayName())) {                    
                    dbCategory = (ProductCategoryImpl) category;            // An Existign category
                    break;          // break the loop
                }
            }
            
            if (dbCategory == null) {  
                ProductCategoryImpl newDBCategory = this.recurisveAddNewCategries(newCategory);

                if (parentCategory != null) {
                    changedCategories.add(parentCategory);
                    parentCategory.getChildren().add(newDBCategory);
                    newDBCategory.getParents().add(parentCategory);  
                    

                    if (!changedCategories.contains(parentCategory)) {
                        changedCategories.add(parentCategory);                         
                    }
                    noChangCategories.remove(parentCategory);        
                }                       
            }
            else {
                // Check for url difference, if there's a difference then update category
                if (isCategoryEquals(dbCategory, newCategory)) {            // User checksum to compare the changes
                    noChangCategories.add(dbCategory);        
                }
                else {
                    changedCategories.add(dbCategory);          // Some unknown field changed, merge the attributes.
                    
                    //dbCategory.mergeEntityAttributes(newCategory);        , this merge merges fields that shouldn't be merged
                    this.mergeCategory(dbCategory, newCategory);
                }
                
                // change the updated Date.
                dbCategory.getAudit().setUpdatedDate(new Date());       
                
                // An Existing Categry - we need to check it's children and try to dedup them.
                recursiveDeDupCategory(dbCategory, dbCategory.getChildren(), newCategory.getChildren()); 
                
                newCategory.setDbProductCategory(dbCategory);
            }
        }
        
        // Look for deleted categories
        
        List <ProductCategory> removeList = new LinkedList<ProductCategory> ();// Work around for concurrence modification exception.
        for (Object dbObj : dbRootCategoryList) {
            ProductCategory category = (ProductCategory) dbObj;
            boolean isDelete = true;
            
            for (Object newObj: rootCategoryList) {
                ProductCategory newCategory = (ProductCategory) newObj;
                if (category.getDisplayName().equals(newCategory.getDisplayName())) {
                    // An Existing category, do not delete this one
                    isDelete = false;
                    break;
                }
            }
            
            if (isDelete) {
                // This path should be removed from database. (or deactived)
                removeList.add(category);           // Work around for concurrence modification exception.
                
                // The function will smartly decide whether to add to removed list or to changed list.
                recursiveRemoveCategories(category);               // Some of the child maybe referenced by someone else.  
            }
        }
        
        //      Work around for concurrence modification exception.
        for (ProductCategory category: removeList) {
            dbRootCategoryList.remove(category);
        }
    }
    
    /**
     * Copy the source category attributes to the target.
     * @param target
     * @param source
     */
    private void mergeCategory(ProductCategory target, ProductCategory source) {
       String[] ignoreFields = new String[] {"dateCreated", "checksum", "feedChecksum", "crawlChecksum", "audit", "id", "parent", "singleParent", "leaf", "root"};
        
        for (Object o: target.getEntityAttributeNames()) {
            String attributeName = (String) o;            
            
            boolean isIgnore = false;
            for (String ignoreField: ignoreFields) {
               if (ignoreField.equals(attributeName)) {
                   isIgnore = true;
                   break;
               }
            }
            
            if (isIgnore) 
                continue;
            
            // Source's object value
            Object sourceValue = source.getEntityAttribute(attributeName);
            
            // Don't copy collection types
            if (sourceValue != null && !(sourceValue instanceof Collection))
            {
                // Assign soruce to target
                target.setEntityAttribute(attributeName, sourceValue);
            }            
        }
    }
    
    /***
     * Return all the fields in the entity in one long string
     * @param entity 
     *          Entity to get the information from
     * @return
     *          string containing all the attribute values in the entity
     */
    private String getEntityValues(Entity entity) {
        String value = "";
        String[] ignoreFields = new String[] {"dateCreated", "checksum", "feedChecksum", "crawlChecksum", "audit", "id", "parent", "singleParent", "leaf", "root"};
        
        for (Object o: entity.getEntityAttributeNames()) {
            String attributeName = (String) o;            
            
            boolean isIgnore = false;
            for (String ignoreField: ignoreFields) {
               if (ignoreField.equals(attributeName)) {
                   isIgnore = true;
                   break;
               }
            }
            
            if (isIgnore) 
                continue;
            
            Object attributeValue = entity.getEntityAttribute(attributeName);
            
            // Don't compare collection and Audit. (probably identifier too)
            if (attributeValue != null && !(attributeValue instanceof Collection))
            {
                value += attributeName + ": " + entity.getEntityAttribute(attributeName).toString() + "\n";
            }            
        }
        
        return value;
    }
    
    /**
     * Calculate the category checksum given a category
     * @param category
     *          Category to calculate the checksum
     * @return
     *          Checksum
     */
    private String calculateCategoryChecksum(ProductCategoryImpl category) {
        String value = this.getEntityValues(category);
        
        for (String path: category.getPaths()) {
            value += path;
        }
        
        return this.getHash(value);
    }
    
    /**
     * Calculate the product checksum
     * @param product
     *          Product to calculate the checksum
     * @return
     *          MD5 hash of the product
     */
    private String calculateProductChecksum(OnlineProduct product) {
        String value = this.getEntityValues(product);

        for (Object obj: product.getClassifications()) {
            ProductCategory category = (ProductCategory) obj;
            value += "," + category.getId();
        }
                
        return this.getHash(value);
    }
    
    /***
     * Determine if the two category is equal by their checksum values
     *  - If the category doesn't have a calculated checksum it will be calculated.
     * @param category2
     * @param category1
     * @return
     */
    private boolean isCategoryEquals(ProductCategoryImpl category2, ProductCategoryImpl category1) {   
        if (category2.getChecksum() == null) {
            //System.out.println("Category2 :" + this.getEntityValues(category2));
            category2.setChecksum(this.calculateCategoryChecksum(category2));
        }
        
        if (category1.getChecksum() == null) {
            //System.out.println("Category1 :" + this.getEntityValues(category1));
            category1.setChecksum(this.calculateCategoryChecksum(category1));
        }
        
        /*
        for (Object obj: category2.getEntityAttributeNames()) {
            String attributeName = (String) obj;            
            Object attributeValue = category1.getEntityAttribute(attributeName);
            Object attributeValue1 = category2.getEntityAttribute(attributeName);
            
            if (attributeValue1 != null && attributeValue != null && !(attributeValue instanceof Collection))
            {
                if (!attributeValue.toString().equals(attributeValue1.toString()))
                   System.out.println("Attribute: " + attributeName);
            }   
        } */
   
        log.debug(category2.getPath() + " != " + category1.getPath());
        
        return category1.getChecksum().equals(category2.getChecksum());
    }
    
    /***
     * Recurisvely add the new categories
     * @param parentCategory
     */
    private ProductCategoryImpl recurisveAddNewCategries(ProductCategory parentCategory) {
        // dbCategory -> category to be saved/presised
        // parentCategory -> current tree level category processing
        
        ProductCategoryImpl dbCategory = (ProductCategoryImpl) ProductCategory.Factory.newInstance();
        this.mergeCategory(dbCategory, parentCategory);
        
        newCategories.add(dbCategory);      // Newly created category
        
        //((ProductCategoryImpl) parentCategory).setDbProductCategory(dbCategory);
        
        parentCategory.setChecksum(this.calculateCategoryChecksum((ProductCategoryImpl) parentCategory));
        dbCategory.setChecksum(parentCategory.getChecksum());
        
        for (Object obj: parentCategory.getChildClassifications()) {
            ProductCategory childCategory = recurisveAddNewCategries((ProductCategory) obj);
            
            dbCategory.getChildClassifications().add(childCategory);
            childCategory.getParents().add(dbCategory);
        }
        
        return dbCategory;
    }
    
    /***
     * Recursively remove existig categoies that no longer exists
     * @param parentCategory
     *          parentCategory to remove
     */
    private void recursiveRemoveCategories(ProductCategory category) {
        // Remove parent category from the child.
        ProductCategory parentCategory = (ProductCategory) category.getParent();      
        
        if (parentCategory != null) {
            category.getParents().remove(parentCategory);
        }
        
        if (category != null && category.getParents().size() == 0) {               // No other category references this cateogry
            removedCategories.add(category);                                  // Some of the child maybe referenced by someone else.  
            
            log.debug("CATEGORY NODE REMOVED: " + ((ProductCategoryImpl) category).getDisplayName());            
            category.setExistsInFeed(false);
        }
        else {
            log.debug("Category Path Removed: " + ((ProductCategoryImpl) category).getPath());
            changedCategories.add(category);          // Child category no longer exists change                
        }
        
        for (Object obj: category.getChildren()) {
            recursiveRemoveCategories((ProductCategory) obj);
        } 
    }
            
    /**
     * This function divide one big list of products into changed product, unchanged product and new products.
     * This function will also update the changed product to database, and also create new products on the database
     * 
     * This function only support list of OnlineProduct
     */
    protected DeDupInfo handleDeDupProducts(java.util.List<OnlineProduct> products)
        throws java.lang.Exception
    {
        if (products.size() == 0 ) {
            return null;             // Nothing to dedup, dedup process is FINISHED!
        }
        
        boolean isCrawl = true;
        
        OnlineProduct firstProduct = products.get(0);
        
        AbstractMerchant merchant = (AbstractMerchant) firstProduct.getMerchant();
        
        // Load the checksum                       
        if (!this.merchantChecksumList.containsKey(merchant)) {
            throw new Exception("Checksum for the merchant is not loaded, call loadMerchant() first.");
        }
        
        MerchantChecksums merchantChecksums = this.merchantChecksumList.get(merchant);
        Map<Object, ChecksumInfo> productHashMap = merchantChecksums.getProductHashMap();         // This list will never be null.
        
        List<Entity> changedProductList = new  LinkedList<Entity>();
        List<Entity> newProductList = new  LinkedList<Entity>();
        List<Entity> noChangeProductList = new  LinkedList<Entity>();
        
        for (OnlineProduct product: products) {            
            String newChecksum =  this.calculateProductChecksum(product);         // Calculate the checksum
            
            // Get the product identifier
            Object productIdentifier = product.getEntityAttribute(merchantChecksums.getProductIdAttributeName());
            if (productHashMap.containsKey(productIdentifier)) {                
                ChecksumInfo checksumInfo = productHashMap.get(productIdentifier);
                
                if (checksumInfo == null) {
                    // This is the case when two same product is crawled/feeded
                    // This code will ignore the second product
                    noChangeProductList.add(product);
                    continue;
                }
                
                String oldChecksum =  checksumInfo.getFeedChecksum();
                if (isCrawl) {
                    oldChecksum =  checksumInfo.getCrawlChecksum();
                }
                
                // Duplicate entity, add to updatelist if checksum don't equal
                if (!newChecksum.equals(oldChecksum)) {
                    changedProductList.add(product);                                        // entity to update
                    updateChecksum(product, isCrawl, newChecksum, checksumInfo);            // assign the new checksum                    
                }           
                else {
                    noChangeProductList.add(product);
                }
                
                // Copy the primary key, it will be neeeded to do the update.
                product.setId(checksumInfo.getPrimaryKey());
            }
            else {
                // Add the new product check sum to hash table.
                ChecksumInfo checksumInfo = new ChecksumInfo();                 
                updateChecksum(product, isCrawl, newChecksum, checksumInfo);
                
                // Add a new identifer with null
                productHashMap.put(productIdentifier, null);            //                  
                newProductList.add(product);
            } 
        }
        
        // We are not keeping track of removed products.
        DeDupInfo deDupInfo = new DeDupInfo(newProductList, changedProductList, noChangeProductList, null);
        
        return deDupInfo;
    }
        
    /***
     * Helper function for handleDeDupProducts, handles switch between crawl and feed.
     * @param product
     *              Product to calculte checksum
     * @param isCrawl
     *              is it a crawler calling this
     * @param newChecksum
     *              the checksum calculated for the product
     */
    private void updateChecksum(OnlineProduct product, boolean isCrawl, String newChecksum, ChecksumInfo checksumInfo) {
        if (isCrawl) {
            product.setCrawlChecksum(newChecksum);   
            checksumInfo.setCrawlChecksum(newChecksum);                  
        }
        else {
            product.setFeedChecksum(newChecksum);      
            product.setCrawlChecksum("");               // Empty out the crawl's checksum      
            checksumInfo.setFeedChecksum(newChecksum);     
        }            
    }
        
    /**
     * Convenience method to convert an int to a hex char.
     *
     * @param i the int to convert
     * @return char the converted char
     */
    private char toHexChar(int i) {
        if ((0 <= i) && (i <= 9))
            return (char) ('0' + i);
        else
            return (char) ('a' + (i - 10));
    }
    /**
     * Convenience method to convert a byte to a hex string.
     *
     * @param data the byte to convert
     * @return String the converted byte
     */
    private String byteToHex(byte data) {
        StringBuffer buf = new StringBuffer();
        buf.append(toHexChar((data >>> 4) & 0x0F));
        buf.append(toHexChar(data & 0x0F));
        return buf.toString();
    }
    
    /**
     * Return the hash value of the given string
     * @param value Given string
     * @return MD5 hash value of the string 
     */
    private String getHash(String value) {
        try {
            byte[] buffer = value.getBytes();
            byte[] key = "key".getBytes();

            String hash = "";
            MessageDigest md5 = MessageDigest.getInstance("MD5");
            md5.reset();
            md5.update(buffer);
            byte[] bytes = md5.digest();
            StringBuffer buf = new StringBuffer();

            //byte[] bytes= md5.digest(key);  // Hash with key
            for (byte theByte : bytes) {
                hash += byteToHex(theByte);
            }
            
            return hash;
        }
        catch (NoSuchAlgorithmException e) {
            System.out.println("Hashing Algorithm not found.");
        }
        return null;
    }

    /**
     * Class for MerchantChecksum. This class hold checksum 
     * informations about product and category for the merchant
     */
    class MerchantChecksums {        
        private String productIdAttributeName;
        private String categoryIdAttributeName;
        private AbstractMerchant merchant;
        
        private Map<Object, ChecksumInfo> productHashMap;         // Map that contains product identifier and checksum
        
        public MerchantChecksums(AbstractMerchant merchant, String productIdAttributeName) {  
            this.productIdAttributeName = productIdAttributeName;
            this.merchant = merchant;
            
            this.productHashMap = getProductDao().loadChecksum(this.merchant, this.productIdAttributeName);            
        }
        
        public Map<Object, ChecksumInfo> getProductHashMap() {
            return this.productHashMap;
        }
        
        public String getProductIdAttributeName() {
            return this.productIdAttributeName;
        }
        
        public String getCategoryIdAttributeName() {
            return this.categoryIdAttributeName;
        }
    }
}