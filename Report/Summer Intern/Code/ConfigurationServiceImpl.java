// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.service.aggregator;

import java.io.File;
import java.io.InputStream;
import java.util.Collection;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.Node;
import org.dom4j.XPath;
import org.dom4j.io.SAXReader;
import org.hibernate.Hibernate;

import com.ten45.basic.util.InitialContextUtil;
import com.ten45.domain.common.MerchantInfo;
import com.ten45.domain.crawler.Merchant;
import com.ten45.domain.crawler.MerchantsDocument;
import com.ten45.domain.crawler.Site;
import com.ten45.entity.aggregation.CrawlElement;
import com.ten45.entity.aggregation.CrawlSession;
import com.ten45.entity.aggregation.CrawlSessionImpl;
import com.ten45.entity.common.AbstractMerchant;

/**
 * @see com.ten45.service.aggregator.ConfigurationService
 */
public class ConfigurationServiceImpl
    extends com.ten45.service.aggregator.ConfigurationServiceBase
{
	static final com.ten45.basic.Log log = com.ten45.basic.Log.getInstance(ConfigurationServiceImpl.class);
	
    static private final String rootPath = "/datafeed/";
    static private final String CRAWL_ROOTH_PATH = "/crawlconfig/";    
    static private final XPath refXPath = DocumentHelper.createXPath("//@ref");
    
    static File workDir = null;
    
    static
    {
    	workDir = InitialContextUtil.loadScriptDir();
    }
    
    /**
     * Save the crawl Session to the database, this will handle Update existing crawlsession 
     * or create a new crawl session in database.
     */
    protected void handleSaveCrawlSession(CrawlSession crawlSession) 
    throws java.lang.Exception 
    {
        // Crawl Session can either be a new crawl session or an existing one
        if (crawlSession.getId() == null) {
            // A new crawl Session
            super.getCrawlSessionDao().create(crawlSession);            
        }
        else {
            // A crawl Sesion to update!
            super.getCrawlSessionDao().update(crawlSession);
        }
        
        // Do i need to do smart create/update?
        getCrawlElementDao().create(crawlSession.getCrawledElements());
        getCrawlElementDao().create(crawlSession.getToCrawlElements());
        
        getCrawlElementDao().update(crawlSession.getCrawledElements());    
        getCrawlElementDao().update(crawlSession.getToCrawlElements()); 
        
        // Save changes to crawl session data table.
        //saveElements(crawlSession);
        
        super.getCrawlSessionDao().flush(); 
        super.getCrawlElementDao().flush();                      // Save all to database   
        
    }    
    
    private void saveElements(CrawlSession crawlSession) {
        List<CrawlElement> updateList = new LinkedList<CrawlElement>();
        List<CrawlElement> createList = new LinkedList<CrawlElement>();
        
        for (Object obj: crawlSession.getCrawledElements()) {
            CrawlElement element = (CrawlElement) obj;
            
            if (element.getId() == null) {
                createList.add(element);
            }
            else {
                updateList.add(element);
            }
                
        }

        for (Object obj: crawlSession.getCrawledElements()) {
            CrawlElement element = (CrawlElement) obj;

            if (element.getId() == null) {
                createList.add(element);
            }
            else {
                updateList.add(element);
            }
        }

        getCrawlElementDao().update(updateList);    
        getCrawlElementDao().create(createList); 
    }
    
    protected void handleClearCrawlSessionElements(CrawlSession crawlSession)
    throws java.lang.Exception 
    {               
        // Remove the elements calling dao, this will remove them from dataabse.
        this.getCrawlElementDao().remove(crawlSession.getToCrawlElements());
        this.getCrawlElementDao().remove(crawlSession.getCrawledElements());
        
        // Clear it in the list too
        crawlSession.getToCrawlElements().clear();
        crawlSession.getCrawledElements().clear();
        
        ((CrawlSessionImpl) crawlSession).loadUrlHash();            // Reset the url hash

        super.getCrawlElementDao().flush();                      // Save all to database    
        super.getCrawlSessionDao().flush();
    }
    
    /**
     * Load crawlsessions from database
     * TODO: Takes existing crawl session so that it doesn't reload the sessions.
     */
    protected List<CrawlSessionImpl> handleLoadCrawlSessions()
        throws java.lang.Exception 
    {        
        List<CrawlSessionImpl> crawlSessions = new LinkedList<CrawlSessionImpl>();
        
        // Use DAO to load existing crawl session in the database.
        Collection sessions = this.getCrawlSessionDao().loadAll();
        for (Object obj : sessions) {            
            CrawlSessionImpl crawlSessionImpl = (CrawlSessionImpl) obj;            
            Hibernate.initialize (crawlSessionImpl.getToCrawlElements());
            Hibernate.initialize (crawlSessionImpl.getCrawledElements());
            
            MerchantInfo merchant = (MerchantInfo) crawlSessionImpl.getMerchant();
            
            if (loadCrawlSession((AbstractMerchant) merchant, crawlSessionImpl) != null) {
                crawlSessions.add(crawlSessionImpl);
            }
            else {
                // Error Sesssion: Missing Config File.
                crawlSessions.add(crawlSessionImpl);
            }
                
        }
        
        log.debug ("-------- LOADED CONFIG FROM DATABASE -----------------");
        log.debug ("Total Config from database: " + sessions.size());
        
        // Discover config files located in the config folder.
        this.handleDiscoverCrawlSessions(crawlSessions);
        return crawlSessions;
    }
    
    /***
     * Discover more crawlsession from the crawlsession folder
     * @param crawlSessions
     */
    public Long handleDiscoverCrawlSessions(List<CrawlSessionImpl> crawlSessions)
    throws java.lang.Exception 
    {
        long count = 0;
        
        // Loads from the merchant file.
        for (Object obj : this.getMerchantManager().findAll("internalName", true)) {
            MerchantInfo merchant = (MerchantInfo) obj;
            
            CrawlSessionImpl crawlSessionImpl = loadCrawlSession((AbstractMerchant) merchant, null);
            if (crawlSessionImpl != null) {             // Config file successfully loaded.
                // See if the crawl session already exists in the database.
                if (!crawlSessions.contains(crawlSessionImpl)) {  
                    crawlSessions.add(crawlSessionImpl);    
                    this.saveCrawlSession(crawlSessionImpl);       // Save the crawl session to database.      
                    count += 1;  
                }     
                else {
                    CrawlSessionImpl dbCrawlSessionImpl = crawlSessions.get(crawlSessions.indexOf(crawlSessionImpl));
                    
                    if (dbCrawlSessionImpl.getSite() == null) {
                        dbCrawlSessionImpl.setSite(crawlSessionImpl.getSite());           // Set the site.        
                        this.saveCrawlSession(dbCrawlSessionImpl);       // Save the crawl session to database.     
                        count += 1;             
                    }
                }
                 
            }
        }
        
        log.debug("Discovered: " + count);
        return count;
    }
	    
    /**
     * Load important crawlsession information from file
     * @param merchantName
     *          Name of the merchant
     * @param oldCrawlSession
     *          old crawler session if loaded from db, else null
     * @return
     *          the crawler session with information from file set, null if the loading failed
     */
    private CrawlSessionImpl loadCrawlSession(AbstractMerchant merchant, CrawlSessionImpl crawlSessionImpl) {
        MerchantsDocument mDoc = null;    
        
        if (crawlSessionImpl == null) {
            // Loading a new crawl Session.
            crawlSessionImpl = new CrawlSessionImpl();
        }
        
        // Try to load the config file.
        String merchantName = merchant.getInternalName();
        String resourceName = CRAWL_ROOTH_PATH + merchantName + ".xml";       
        
        try {
            InputStream in = this.getClass().getResourceAsStream(resourceName);                
            mDoc = MerchantsDocument.Factory.parse(in);
            
        }
        catch (Exception ex) {
            log.debug(ex.getMessage());
            log.debug(ex.getStackTrace());
            
            crawlSessionImpl = null;            // Load failed
        }          
        
        try{
            if (mDoc != null)  {
                Merchant merchantElement = mDoc.getMerchants().getMerchant();
                
                //log.debug ("Class path: " + this.getClass().getResource(resourceName));

                // Get Sites to Crawl
                for (Site site : merchantElement.getSiteList()) {                        
                    crawlSessionImpl.setSite(site);        
                    //crawlSessionImpl.setStartDate(new Date());          // TODO: make db accept null
                    //crawlSessionImpl.setEndDate(new Date());            // TODO: make db accept null
                    
                    // Settitng site will set everythign else.
                    crawlSessionImpl.setMerchant(merchant);              // Set the merchant.
                }
                log.debug("Loaded: " + resourceName);                     
             }
        }
        catch (Exception ex) {
            log.debug(ex.getMessage());
            log.debug(ex.getStackTrace());
            
            crawlSessionImpl = null;            // Load failed.
        }  
        
        return crawlSessionImpl;
    }
    
    /**
     * Load crawl elements from database.
     * @param crawlSessionImpl
     *              crawl session to load the crawlelement to
     */
    private void loadCrawlElements(CrawlSessionImpl crawlSessionImpl) {
        crawlSessionImpl.setCrawledElements(this.getCrawlElementDao().loadCrawlElements(crawlSessionImpl, true));
        crawlSessionImpl.setToCrawlElements(this.getCrawlElementDao().loadCrawlElements(crawlSessionImpl, false));
    }
    
    /**
     * @see com.ten45.service.aggregator.ConfigurationService#getConfiguration(java.lang.String)
     */
    protected Object handleFindConfiguration(java.lang.String merchantName)
        throws java.lang.Exception
    {
    	String resourceName = rootPath + merchantName + ".xml";
    	InputStream in = this.getClass().getResourceAsStream(resourceName);
    	SAXReader reader = new SAXReader();
    	Document doc = null;
    	// Select and expand all reference nodes.
        try {
        	if (in != null)
        	{
			    doc = reader.read(in);
			    List nodes = refXPath.selectNodes(doc);
			    while (nodes != null && nodes.size() > 0) {
			    	for (int i = 0; i < nodes.size(); i++) {
			    		Node node = (Node) nodes.get(i);
			    		doc = expandReference(doc, node);
			    		log.debug(doc.asXML());
			    	}
			    	nodes = refXPath.selectNodes(doc);
			    }
        	}
        	else
        	{
        		log.warn("Can't find resource " + resourceName);
        	}
        }
        catch (DocumentException de) {
			throw new Exception(de);
		}
        return doc;
    }

    
    protected FtpParameter handleFindFtpParameter(String group)
    {
    	// @todo implement protected FtpParameter handleFindFtpParameter(String group)
    	Map<String, List<String>> map = this.getConfigurationParameterDao().getValuesByGroup(group);
    	FtpParameter param = null;
    	if (map.containsKey("host"))
    	{
    		param = new FtpParameter();
    		param.setHost(map.get("host").get(0));
    		if (map.containsKey("username"))
        	{
        		param.setUsername(map.get("username").get(0));
        	}
        	if (map.containsKey("password"))
        	{
        		param.setPassword(map.get("password").get(0));
        	}
        	if (map.containsKey("passiveMode"))
        	{
        		param.setPassiveMode(Boolean.parseBoolean((String)map.get("passiveMode").get(0)));
        	}
        	if (map.containsKey("remoteDir"))
        	{
        		param.setRemoteDir(map.get("remoteDir").get(0));
        	}
            param.setLocalDir(workDir.getAbsolutePath() + File.separatorChar + "ftp");
        	if (map.containsKey("binaryMode"))
        	{
        		param.setBinaryMode(Boolean.parseBoolean((String)map.get("binaryMode").get(0)));
        	}
        	if (map.containsKey("pattern"))
        	{
        		param.setPattern(map.get("pattern").get(0));
        	}
    	}
    	else
    	{
    		log.warn("Ftp host undefined for group " + group + ".");
    	}
    	
    	return param;
    }
    
    
    /**
     * Expand the original configuration document with the referred node.
     * It reads the referred document, finds the referred element in the same 
     * path as the original document, and moves all the children of the 
     * referred element into the original element.
     * 
     * @param doc
     * @param node
     * @return
     * @throws DocumentException
     */
    private Document expandReference (Document doc, Node node) throws DocumentException
    {
    	// Find the 'anchor' element that contains the reference declaration.
    	Element anchor = node.getParent();
    	XPath anchorXPath = DocumentHelper.createXPath(anchor.getPath());
    	
    	// Remove the reference declaration node from the document.
    	node.detach();

    	// Read the new configuration.
    	String resourceName = rootPath + node.getText() + ".xml";
    	log.debug("Reading resource " + resourceName);
    	InputStream in = this.getClass().getResourceAsStream(resourceName);
    	SAXReader reader = new SAXReader();
    	try {
    		Document refDoc = reader.read(in);
    		
    		Element refElement = (Element) anchorXPath.selectSingleNode(refDoc);
    		if (refElement != null) {
    			log.debug("Expanding " + anchorXPath.getText() + " with " + refElement.asXML());
	    		// Move all elements from the referenced document into the anchor.
	    		List children = refElement.elements();
	    		if (children != null && children.size() > 0) {
	    			for (int i = 0; i < children.size(); i++) {
	    				Element child = (Element) children.get(i);
	    				XPath refXPath = DocumentHelper.createXPath(child.getPath());
	    				if (refXPath.selectSingleNode(doc) == null) {
	    					log.debug("Adding element " + refXPath.getText());
		    				child.detach();
		    				anchor.add(child);
	    				}
	    				else {
	    					log.debug("Ignore pre-existing element " + refXPath.getText());
	    				}
	    			}
	    		}
    		}
    	}
    	catch (DocumentException de) {
			throw de;
		}
    	return doc;
    }

}