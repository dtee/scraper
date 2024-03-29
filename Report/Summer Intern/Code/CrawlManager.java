// license-header java merge-point
//
// Attention: Generated code! Do not modify by hand!
// Generated by: SpringService.vsl in andromda-spring-cartridge.
//
package com.ten45.manager.aggregator;

/**
 * 
 */
public interface CrawlManager
    extends com.ten45.manager.aggregator.AbstractAggregationManager
{

    /**
     * 
     */
    public void StartCrawl(java.lang.Long CrawlSessionID, boolean isDebug);

    /**
     * 
     */
    public void StopAll();

    /**
     * 
     */
    public void LoadConfig();

    /**
     * 
     */
    public java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> getCrawlingSession();

    /**
     * 
     */
    public java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> getToCrawlSessions();

    /**
     * 
     */
    public void stopCrawl(java.lang.Long crawlSessionID);

    /**
     * 
     */
    public void resetCrawlSession(java.lang.Long crawlSessionID);

    /**
     * <p>
     * return the total sessions discovered.
     * </p>
     */
    public java.lang.Long discoverCrawlSessions();

    /**
     * 
     */
    public void loadCrawlElements(java.lang.Long crawlSessionID, java.lang.Integer crawlType);


    static final com.ten45.basic.Log log = com.ten45.basic.Log.getInstance( CrawlManager.class );

}
