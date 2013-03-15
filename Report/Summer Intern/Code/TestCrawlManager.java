package com.ten45.manager.aggregator;

import java.util.Collection;
import java.util.List;

import com.ten45.basic.util.IOUtil;
import com.ten45.entity.aggregation.CrawlSession;
import com.ten45.entity.aggregation.CrawlSessionImpl;
import com.ten45.entity.online.OnlineMerchant;
import com.ten45.entity.online.OnlineMerchantDao;
import com.ten45.entity.product.ProductCategory;
import com.ten45.service.aggregator.ConfigurationService;
import com.ten45.test.AbstractContextBasedTest;

public class TestCrawlManager extends AbstractContextBasedTest
{
    protected ConfigurationService configurationService;

    protected OnlineMerchantDao onlineMerchantDao;
    
    protected CrawlManager crawlManager;
    
    protected ClassificationManager classificationManager;
    
    /*
     * Load crawl config file.
     */
    public void loadConfig ()
    {

    }
    
    public void testProductDetailCrawl() {
        
    }
    
    public void testProductsCrawl() {
        
    }
    
    public void testLoadConfig ()
    {
        List<CrawlSessionImpl> crawlSessions = crawlManager
                .getToCrawlSessions();

        OnlineMerchant m = OnlineMerchant.Factory.newInstance();
        m.setDisplayName("Backcountry.com");
        m.setInternalName("backcountry");
        m.setMainUrl(IOUtil.getUrl("http://backcountry.com/"));

        // Add the merchant to db
        onlineMerchantDao.create(m);
        onlineMerchantDao.flush();

        assertEquals(new Long(1), crawlManager.discoverCrawlSessions());
        crawlSessions = crawlManager.getToCrawlSessions();

        assertEquals(2, crawlManager.getToCrawlSessions().size());
        
        // Try to rediscover
        assertEquals(new Long(0), crawlManager.discoverCrawlSessions());
        crawlSessions = crawlManager.getToCrawlSessions();
        
        // Test Clear
        
    }

    public void Crawl ()
    {       
        OnlineMerchant m = OnlineMerchant.Factory.newInstance() ; 
        m.setDisplayName("Backcountry.com");
        m.setInternalName("backcountry");
        m.setMainUrl(IOUtil.getUrl("http://backcountry.com/"));
       
        // Add the merchant to db
        onlineMerchantDao.create(m);
        onlineMerchantDao.flush();

        List<CrawlSessionImpl> crawlSessions = crawlManager.getToCrawlSessions();

        assertEquals(2, crawlSessions.size());
        
        // Lets start up a new crawl session?
        CrawlSessionImpl crawlSession = null;
        for (CrawlSessionImpl temp: crawlSessions) {
            System.out.println(temp.getId() + " : " + temp.getSiteUrl().toString());
            if (temp.getMerchant().getInternalName().equals(m.getInternalName())) {
                crawlSession = temp;
            }
        }

        crawlManager.loadCrawlElements(crawlSession.getId(), CrawlManagerImpl.CRAWL_TYPE_CATEGORY);
        System.out.println("Total to Crawl Elements: " + crawlSession.getToCrawlElements().size());
        
        crawlManager.StartCrawl(crawlSession.getId(), true);          // Need to wait for the thread to finish.
        
        // Load Categories, see if some categoies are saved.
        System.out.println("============ Reloading Categories =============");
        List<ProductCategory> categories = classificationManager.loadCategories("category:backcountry");
        assertEquals(12, categories.size()); // "Crawled category is not the same."'
        
        // Crawl categories again
        crawlManager.loadCrawlElements(crawlSession.getId(), CrawlManagerImpl.CRAWL_TYPE_CATEGORY);         
        crawlManager.StartCrawl(crawlSession.getId(), true);          // Need to wait for the thread to finish.

        //assertEquals(12, categories.size()); // "Crawled category is not the same."'
        
        // Start Products Crawl
        crawlManager.loadCrawlElements(crawlSession.getId(), CrawlManagerImpl.CRAWL_TYPE_PRODUCTS);
        
        // Start product Detail crawl
        assertTrue(50 < crawlSession.getTotalURLCount()); 
        
        System.out.println("============ Starting Product Crawl ============="); 
        crawlManager.StartCrawl(crawlSession.getId(), true);          // Try to crawl for some products   

        System.out.println("============ Crawling more Product  ============="); 
        crawlManager.StartCrawl(crawlSession.getId(), true);          // Try to crawl for some products   
        
        System.out.println("============ Crawling more Product  ============="); 
        crawlManager.StartCrawl(crawlSession.getId(), true);          // Try to crawl for some products   
        
        // Start Product Detail Crawl
        crawlManager.loadCrawlElements(crawlSession.getId(), CrawlManagerImpl.CRAWL_TYPE_PRODUCTDETAILS);        
    }
}
