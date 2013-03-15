// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.manager.aggregator;

import java.util.Date;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.w3c.dom.Document;

import com.ten45.basic.Log;
import com.ten45.domain.crawler.DeDupInfo;
import com.ten45.entity.Entity;
import com.ten45.entity.aggregation.CrawlElement;
import com.ten45.entity.aggregation.CrawlElementImpl;
import com.ten45.entity.aggregation.CrawlSessionImpl;
import com.ten45.entity.online.OnlineProduct;
import com.ten45.entity.product.ProductCategory;
import com.ten45.entity.product.ProductCategoryImpl;

/**
 * @see com.ten45.manager.aggregator.CrawlManager
 */
public class CrawlManagerImpl
    extends com.ten45.manager.aggregator.CrawlManagerBase
{
    
    private static ExecutorService executor = Executors.newFixedThreadPool( 30 );
    private List<CrawlSessionImpl> crawlSessions;
    
    protected Long handleDiscoverCrawlSessions() {
        return this.getConfigurationService().discoverCrawlSessions(this.crawlSessions);
    }
    
    /**
     * Performs the core logic for {@link #stopCrawl(java.lang.Long)}
     */
   protected void handleStopCrawl(java.lang.Long crawlSessionID)
       throws java.lang.Exception {
       // Check the crawlSessions, if it nothing, then load config.
       
       CrawlSessionImpl crawlSession = this.getCrawlSessionImplToCraw(crawlSessionID);
       if (crawlSession == null) {
           throw new Exception("Error: Crawl Session ID is not found in current list of sessions.");
       }
       
       if (!crawlSession.getIsRunning()) {
           throw new Exception("Error: The crawl session is currently NOT running.");
       }
       else {     
           crawlSession.setIsAbort(true);           // Abort signal
       }
   }
   
   protected void handleResetCrawlSession(java.lang.Long crawlSessionID)
       throws java.lang.Exception {
       // Check the crawlSessions, if it nothing, then load config.
       
       CrawlSessionImpl crawlSession = this.getCrawlSessionImplToCraw(crawlSessionID);
       if (crawlSession == null) {
           throw new Exception("Error: Crawl Session ID is not found in current list of sessions.");
       }
       
       if (crawlSession.getIsRunning()) {
           throw new Exception("Error: Can't reset a running session.");
       }
       else {     
           crawlSession.Reset();
           this.getConfigurationService().saveCrawlSession(crawlSession);
       }
   }
   
    /**
     * @see com.ten45.manager.aggregator.CrawlManager#StartCrawl(com.ten45.entity.aggregation.CrawlSession)
     */
    protected void handleStartCrawl(Long crawlSessionID, boolean isDebug)
        throws java.lang.Exception
    {
        // Check the crawlSessions, if it nothing, then load config.
                
        CrawlSessionImpl crawlSession = this.getCrawlSessionImplToCraw(crawlSessionID);
        if (crawlSession == null) {
            throw new Exception("Error: Crawl Session ID is not found in current list of sessions.");
        }
        
        if (crawlSession.getIsRunning()) {
            throw new Exception("Error: The crawl session is currently running.");
        }
        else {
            // Load dedup product information
            this.getCrawlDeDupService().loadChecksum(crawlSession.getMerchant(), "impressionUrl");
            
            CrawlerTask crawlTask = new CrawlerTask(crawlSession);    
            crawlTask.IsDebugMode = isDebug;
            crawlTask.run();            // Singal thread operation for testing.
            //executor.execute(crawlTask);                      
        }
    }
    
    /**
     * Shut down all the crawl sessions
     */
    protected  void handleStopAll()
    throws java.lang.Exception {     
        //executor.shutdown();     
        
        for (CrawlSessionImpl cs: this.getCrawlingSession()) {
            cs.setIsAbort(true);         // Signal all to abort
        }
    }
    
    /**
     * Load new configurations
     * TODO: Implement loading config on the fly - for example, a new merchant with new config file.
     */
    protected  void handleLoadConfig()
    throws java.lang.Exception {
       // Call load config, add stuffs that we don't have yet to the session list
    }
    
    // Find a crawl session from the toCrawl List.
    private CrawlSessionImpl getCrawlSessionImplToCraw(long id) {        
        for (CrawlSessionImpl crawlSession: this.crawlSessions) {           
            if (id == crawlSession.getId()) {
                return crawlSession;
            }
        }
        return null;
    }
    
    /**
     * Return the list of sessions currently crawling
     */
    protected  java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> handleGetCrawlingSession()
    throws java.lang.Exception {
        if (this.crawlSessions == null) {
            crawlSessions = this.getConfigurationService().loadCrawlSessions();
        }
        
        List<CrawlSessionImpl> crawlingSessions;
        crawlingSessions = new LinkedList<com.ten45.entity.aggregation.CrawlSessionImpl>();
        for (CrawlSessionImpl cs: this.crawlSessions) {
            if (cs.getIsRunning() ) {
                crawlingSessions.add(cs);                
            }
        }
        return crawlingSessions;
    }
    
    /**
     * Return the list of session that we can craw, but is not currently crawling.
     */
    protected java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> handleGetToCrawlSessions()
    throws java.lang.Exception {
        if (this.crawlSessions == null) {
            crawlSessions = this.getConfigurationService().loadCrawlSessions();
        }
        
        List<CrawlSessionImpl> toCrawlSessions;
        toCrawlSessions = new LinkedList<com.ten45.entity.aggregation.CrawlSessionImpl>();
        for (CrawlSessionImpl cs: this.crawlSessions) {
            if (!cs.getIsRunning() && cs.getSite() != null) {
                toCrawlSessions.add(cs);                
            }
        }
        return toCrawlSessions;
    }
    
    protected void handleLoadCrawlElements(Long crawlSessionID, Integer crawlType) 
    throws java.lang.Exception 
    { 
        CrawlSessionImpl crawlSession = this.getCrawlSessionImplToCraw(crawlSessionID);
        if (crawlSession == null) {
            throw new Exception("Error: Crawl Session ID is not found in current list of sessions.");
        }
        
        if (crawlSession.getIsRunning()) {
            throw new Exception("Error: Can't load/reset a running session.");
        }
        
        else {                 
            // Clear the crawl Session            
            this.getConfigurationService().clearCrawlSessionElements(crawlSession);
            
            if (crawlType == CRAWL_TYPE_CATEGORY) {
                crawlSession.Reset();                     
            }
            else {
                // Start new Feed Sesssion  
                crawlSession.setFeedID(getProductFeedManager().createFeed(crawlSession.getMerchant().getDisplayName(), false));
                
                if (crawlType  == CRAWL_TYPE_PRODUCTS) {
                    this.getProductCategoryDao ().loadCrawlElements(crawlSession);    
                }
                else if (crawlType == CRAWL_TYPE_PRODUCTDETAILS) {
                    this.getOnlineProductDao().loadCrawlElements(crawlSession);
                }

                // Don't save category stuffs.
                this.getConfigurationService().saveCrawlSession(crawlSession);                
            }
            crawlSession.setCrawlType(crawlType);
        }
    }
        
    public static final int CRAWL_TYPE_CATEGORY = 0;
    public static final int CRAWL_TYPE_PRODUCTS = 1;
    public static final int CRAWL_TYPE_PRODUCTDETAILS = 2;
    
    public class CrawlerTask implements Runnable    {
        private CrawlSessionImpl crawlSession;
        private Document CurrentDoc;
        private CrawlElement currentCawlElement;
        private String debugInfo;           // Debug information for debug mode.

        // These can be set by xml file
        public final int MAX_ERRORS = 50;
        public final int MAX_URL_BEFORE_UPDATE = 5;

        public boolean IsDebugMode = true;   
        
        private java.util.Map<String, ProductCategory> categoryEntityList = new HashMap<String, ProductCategory>();
        private java.util.List<OnlineProduct> productEntityList = new LinkedList<OnlineProduct>();
        private List<ProductCategory> rootCategories = new LinkedList<ProductCategory>();

        public CrawlerTask(CrawlSessionImpl crawlSession) {
            this.crawlSession = crawlSession; 
        }
        
        public void run() {            
            // Reset Stat Data
            crawlSession.setStartDate(new Date());
            crawlSession.setEndDate(null);                  // Take away the end date.
            crawlSession.setIsRunning(true);
            crawlSession.setIsAbort( false);                // Reset the signal to abort
                        
            // Set the start time        
            currentCawlElement = this.crawlSession.getCrawlElement();
            for (; currentCawlElement != null; currentCawlElement = this.crawlSession.getCrawlElement()) {
                
                if (this.crawlSession.getIsAbort()) {
                    crawlSession.setPhase("Aborting");
                    break;          // Singal to abort is set: Stop the crawling!
                }
                
                 try {
                    // TODO: User service to download html
                     crawlSession.setPhase("Downloading");
                     System.out.println("Downloading: " + this.currentCawlElement.getUrl().toString());
                     
                     
                    String result = getHttpDownloadManager().getData(this.currentCawlElement.getUrl());
                    log.debug ("Downloaded: " + this.currentCawlElement.getUrl());

                    crawlSession.setPhase("Converting to DOM");
                    CurrentDoc = getDomParsingManger().getDocument(result);

                    // TODO: Apply XSL to DOM - a fine place to do XSL tranform here.
                    
                    if (getCrawlExtractionManager().extractData(this.categoryEntityList,
                            this.productEntityList, this.crawlSession, this.currentCawlElement, 
                            this.CurrentDoc) == true) {
                        // Success Crawl
                        crawlSession.setSuccessCount(crawlSession.getSuccessCount() + 1);                        
                    }

                }
                catch (Exception e) {
                    System.out.println(e.getMessage());
                    System.out.println(e.getStackTrace());
                    crawlSession.setErrorCount(crawlSession.getErrorCount() + 1);
                }

                // break out of for loop if there too many error
                if (crawlSession.getErrorCount() > this.MAX_ERRORS) {
                    break;      // Stop the crawling... Too much error
                }         
                
                if (IsDebugMode) {// Group Groups + 4 links
                    int totalGroup = this.crawlSession.getSite().getGroupList().size();
                    if ((crawlSession.getSuccessCount() + crawlSession.getErrorCount()) % totalGroup == 0) {
                        break;  // Debug mode: Stop the crawling early
                    }
                }
                else {
                    if (this.crawlSession.getCrawlType() != CRAWL_TYPE_CATEGORY) {
                        if (this.crawlSession.getErrorCount() + this.crawlSession.getSuccessCount() % this.MAX_URL_BEFORE_UPDATE == 0) {
                            updateData();           // Update Data                    
                        }
                    }
                }
                System.out.println("Total url so far: " + this.crawlSession.getTotalURLCount());
                
            }   // End for

            crawlSession.setEndDate(new Date());          // Crawling Finished, YAY!
            crawlSession.setIsRunning(false);             // Change the running state
            
            // Finished Crawling the site: Update data to Database
            if (this.IsDebugMode) {
                this.PrintCata();               // Set the category tree     
                
                String out = "-------------------------------------------------------------------\n";
                out = out + "            " + this.crawlSession.getMerchant().getDisplayName() + "           \n";
                out = out + "-------------------------------------------------------------------\n";
                out = out + "Finished Crawling: " + this.categoryEntityList.size() + " Category/ " + this.productEntityList.size() + " Products\n";
                out = out + "Total of : " + crawlSession.getErrorCount() + " Error/ " +  crawlSession.getSuccessCount() + " Success\n";
                out = out + "Total of  " + crawlSession.getTotalURLCount();
                out = out + "Url/  " + crawlSession.getEstimatedRemainingUrlCount() + " Url Left\n";
                out = out + "-------------------------------------------------------------------\n";
                
                log.debug(out);
                System.out.println(out);
                
                this.debugInfo += out;
                this.crawlSession.setDebugString(this.debugInfo);          // Set Debug info

                updateData();           // Update Data
            }       
            else if(this.crawlSession.getCrawlType() != CRAWL_TYPE_CATEGORY && this.crawlSession.getIsAbort()) {
                // Do not update data, we only update category if the whole category is crawled
                //updateData();           // Update Data
            }
            else { 
                updateData();           // Update Data
            }

            if (this.crawlSession.getIsAbort()) {
                crawlSession.setPhase("Aborted");
            }
            else {
                this.crawlSession.setPhase("Finished Crawling.");             // How do i noticfy the thread?                
            }
        }
        
        /**
         * Update the categories crawled.
         *
         */
        private void updateCategories() {
            DeDupInfo dDup = getCrawlDeDupService().deDupCategories(this.getRootCategoies());

            // Use Category dao to update/create to database
            if (dDup != null) {                                   
                this.crawlSession.setPhase("Updating Categories.");
                
                log.debug("Total Categories:            " + this.categoryEntityList.values().size());
                
                int pathCount = 0;
                for (Object obj: this.categoryEntityList.values()) {
                    ProductCategoryImpl cata = (ProductCategoryImpl) obj;
                    pathCount += cata.getPaths().size();
                }
                
                log.debug("Total Paths:                 " + pathCount);                
                log.debug("Total NEW Categories:        " + dDup.getNewList().size());
                log.debug("Total NO change Categories:  " + dDup.getNoChangeList().size());
                log.debug("Total REMOVED Categories:    " + dDup.getRemovedList().size());
                
                System.out.println("Total Paths:                 " + pathCount);                
                System.out.println("Total NEW Categories:        " + dDup.getNewList().size());
                System.out.println("Total NO change Categories:  " + dDup.getNoChangeList().size());
                System.out.println("Total REMOVED Categories:    " + dDup.getRemovedList().size());
                

                this.crawlSession.setPhase("Updating CrawlSessions.");  
                System.out.println("Total Crawled: " + this.crawlSession.getCrawledElements().size());
                System.out.println("Total to Crawl: " + this.crawlSession.getToCrawlElements().size());
                
                for (Object obj: this.crawlSession.getToCrawlElements()) {
                    CrawlElement crawlElement = (CrawlElement) obj;                    
                    ProductCategoryImpl temp = (ProductCategoryImpl) crawlElement.getCategory();     
                    crawlElement.setCategory(temp.getDbProductCategory());
                    crawlElement.setCategory(null);
                }        

                for (Object obj: this.crawlSession.getCrawledElements()) {
                    CrawlElement crawlElement = (CrawlElement) obj;                    
                    ProductCategoryImpl temp = (ProductCategoryImpl) crawlElement.getCategory();   
                    
                    if (temp != null) {
                        crawlElement.setCategory(temp.getDbProductCategory());
                    }
                    crawlElement.setCategory(null);
                }       

                //getConfigurationService().saveCrawlSession(this.crawlSession);
                
                getProductCategoryDao().create(dDup.getNewList());
                getProductCategoryDao().update(dDup.getChangedList());
                getProductCategoryDao().update(dDup.getNoChangeList());
                
                // Category exists in the feed
                for (Entity entity : dDup.getRemovedList()) {
                    ProductCategory category = (ProductCategory) entity;
                    category.setExistsInFeed(false);
                }
                
                getProductCategoryDao().update(dDup.getRemovedList());             
                
                // Update the merchant       
                // getAbstractMerchantDao().update(this.crawlSession.getMerchant());           
                // getAbstractMerchantDao().flush();
                getProductCategoryDao().flush();
                
                log.debug("Categories updated!");
            }
        }
        
        /**
         * Update products to database.
         *
         */
        private void updateProducts() {
            System.out.println("Total Products: " + this.productEntityList.size());
            DeDupInfo dDup = getCrawlDeDupService().deDupProducts(this.productEntityList);

            if (dDup != null) {
                this.crawlSession.setPhase("Updating Products.");

                log.debug("Total NEW Products:        " + dDup.getNewList().size());
                log.debug("Total CHANGED Products:    " + dDup.getChangedList().size());
                log.debug("Total NO change Products:  " + dDup.getNoChangeList().size());
                
                this.crawlSession.setPhase("Updating Products.");
                getOnlineProductDao().saveDeDup(dDup, this.crawlSession.getFeedID());
                
            }
            
            Long feedID = this.crawlSession.getFeedID();
            String merchantName = this.crawlSession.getMerchant().getDisplayName();
            
            // TODO: Remove thsi code after debugging/unit testing is done, same code is placed after the the 
            getProductStagingManager().updateFeed(this.crawlSession.getFeedID(), FeedStatus.RAW_TO_STAGED);
            log.debug("Status: " + getProductStagingManager().rawToStaged(merchantName,feedID, new Date()));
            
            // Crawling seesion finished - we can do staging here
            if (this.crawlSession.getToCrawlElements().size() == 0) {
                // Stage the project
                // TODO: Remove thsi code, same code is placed after the the 
                getProductStagingManager().updateFeed(this.crawlSession.getFeedID(), FeedStatus.RAW_TO_STAGED);
                log.debug("Status: " + getProductStagingManager().rawToStaged(merchantName,feedID, new Date()));
                
                // Make the product live
                getProductStagingManager().updateFeed(feedID, FeedStatus.STAGED_TO_LIVE);
                log.debug("Status: " + getProductStagingManager().stagedToLive(merchantName, feedID, new Date()));
            }
            
            //getConfigurationService().saveCrawlSession(this.crawlSession);
        }
        
        /**
         * Update the product entity list and category list to database
         */
        private void updateData() {
            crawlSession.setPhase("Updating data to database."); 
            
            if (this.crawlSession.getCrawlType() == CRAWL_TYPE_CATEGORY) {
                this.updateCategories();
            }
            else {
                // Update products
                updateProducts();
            }
        }
        
        /**
         * Print the Sample Scrapped Data: Calls recursive print
         */
        private void PrintCata() {
            log.debug("Printing Category tree:");
            for (ProductCategory category: this.getRootCategoies()) {
                PrintCata(category, "");  
            }
        }
        
        private List<ProductCategory> getRootCategoies() {
            List<ProductCategory> categories = new LinkedList<ProductCategory>();
            for (ProductCategory category: this.categoryEntityList.values()) {
                if (category.getParent() == null) {
                    categories.add(category);                   
                }
            }
            
            return categories;
        }

        /**
         * Recursive Print the Sample Scrapped Data
         * @param productCategory ProductCategory Root Product Category
         * @param space String Spacing, start with ""
         */
        private void PrintCata(ProductCategory productCategory, String space) {
            String out = space + productCategory.getDisplayName() + "\t" + productCategory.getUrl() + "\n";
            log.debug(out);

            this.debugInfo += out;
            for (Object obj: productCategory.getChildren()) {
                if (obj instanceof ProductCategory) {
                    ProductCategory child = (ProductCategory) obj;
                    PrintCata(child,space + "\t");
                }
            }

            // Leaf Category, it should have child.
            if (productCategory.getChildren().size() == 0) {
                String productOut = "";
                productOut += (space + "\t============== Products ================Price ===== Sale  ====== Url\n");
                
                /* print the product under this category */ 
                for (OnlineProduct p : this.productEntityList) {
                    productOut = space + "\t" +  p.getTitle() + "\t" + p.getPricing().getUpperSalePrice();
                    productOut = out + "\t" + p.getPricing().getLowerSalePrice() + "\t" + p.getBuyUrl() + "\n";
                    
                    this.debugInfo += productOut;
                    log.debug(productOut);
                }
            }
        }
        
        /**
         * Get product given a productCategory
         * @param productCategory
         *          product category in which the product is child of
         * @return
         *          list of products under the product category
         */
        private List<OnlineProduct> getProduct(ProductCategory productCategory) {
            List<OnlineProduct> productList = new LinkedList<OnlineProduct>();
            
            for (OnlineProduct product : this.productEntityList) {
                if (product.getClassifications().contains(productCategory)) {
                    productList.add(product);
                }
            }
            
            return productList;
        }
    }    
    
    Log log = Log.getInstance(CrawlManagerImpl.class);
}