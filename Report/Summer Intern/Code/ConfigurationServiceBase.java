// license-header java merge-point
//
// Attention: Generated code! Do not modify by hand!
// Generated by: SpringServiceBase.vsl in andromda-spring-cartridge.
//
package com.ten45.service.aggregator;

/**
 * <p>
 * Spring Service base class for <code>com.ten45.service.aggregator.ConfigurationService</code>,
 * provides access to all services and entities referenced by this service.
 * </p>
 *
 * @see com.ten45.service.aggregator.ConfigurationService
 */
public abstract class ConfigurationServiceBase
    implements com.ten45.service.aggregator.ConfigurationService
{

    private com.ten45.manager.aggregator.MerchantManager merchantManager;

    /**
     * Sets the reference to <code>merchantManager</code>.
     */
    public void setMerchantManager(com.ten45.manager.aggregator.MerchantManager merchantManager)
    {
        this.merchantManager = merchantManager;
    }

    /**
     * Gets the reference to <code>merchantManager</code>.
     */
    protected com.ten45.manager.aggregator.MerchantManager getMerchantManager()
    {
        return this.merchantManager;
    }

    private com.ten45.service.aggregator.ConfigurationParameterDao configurationParameterDao;

    /**
     * Sets the reference to <code>configurationParameter</code>'s DAO.
     */
    public void setConfigurationParameterDao(com.ten45.service.aggregator.ConfigurationParameterDao configurationParameterDao)
    {
        this.configurationParameterDao = configurationParameterDao;
    }

    /**
     * Gets the reference to <code>configurationParameter</code>'s DAO.
     */
    protected com.ten45.service.aggregator.ConfigurationParameterDao getConfigurationParameterDao()
    {
        return this.configurationParameterDao;
    }

    private com.ten45.entity.aggregation.CrawlSessionDao crawlSessionDao;

    /**
     * Sets the reference to <code>crawlSession</code>'s DAO.
     */
    public void setCrawlSessionDao(com.ten45.entity.aggregation.CrawlSessionDao crawlSessionDao)
    {
        this.crawlSessionDao = crawlSessionDao;
    }

    /**
     * Gets the reference to <code>crawlSession</code>'s DAO.
     */
    protected com.ten45.entity.aggregation.CrawlSessionDao getCrawlSessionDao()
    {
        return this.crawlSessionDao;
    }

    private com.ten45.entity.aggregation.CrawlElementDao crawlElementDao;

    /**
     * Sets the reference to <code>crawlElement</code>'s DAO.
     */
    public void setCrawlElementDao(com.ten45.entity.aggregation.CrawlElementDao crawlElementDao)
    {
        this.crawlElementDao = crawlElementDao;
    }

    /**
     * Gets the reference to <code>crawlElement</code>'s DAO.
     */
    protected com.ten45.entity.aggregation.CrawlElementDao getCrawlElementDao()
    {
        return this.crawlElementDao;
    }

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#findConfiguration(java.lang.String)
     */
    public java.lang.Object findConfiguration(java.lang.String merchantName)
    {
        if (merchantName == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.service.aggregator.ConfigurationService.findConfiguration(java.lang.String merchantName) - 'merchantName' can not be null");
        }
        try
        {
            return this.handleFindConfiguration(merchantName);
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.findConfiguration(java.lang.String merchantName)' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #findConfiguration(java.lang.String)}
      */
    protected abstract java.lang.Object handleFindConfiguration(java.lang.String merchantName)
        throws java.lang.Exception;

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#findFtpParameter(java.lang.String)
     */
    public com.ten45.service.aggregator.FtpParameter findFtpParameter(java.lang.String groupBy)
    {
        if (groupBy == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.service.aggregator.ConfigurationService.findFtpParameter(java.lang.String groupBy) - 'groupBy' can not be null");
        }
        try
        {
            return this.handleFindFtpParameter(groupBy);
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.findFtpParameter(java.lang.String groupBy)' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #findFtpParameter(java.lang.String)}
      */
    protected abstract com.ten45.service.aggregator.FtpParameter handleFindFtpParameter(java.lang.String groupBy)
        throws java.lang.Exception;

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#loadCrawlSessions()
     */
    public java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> loadCrawlSessions()
    {
        try
        {
            return this.handleLoadCrawlSessions();
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.loadCrawlSessions()' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #loadCrawlSessions()}
      */
    protected abstract java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> handleLoadCrawlSessions()
        throws java.lang.Exception;

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#saveCrawlSession(com.ten45.entity.aggregation.CrawlSession)
     */
    public void saveCrawlSession(com.ten45.entity.aggregation.CrawlSession crawlSession)
    {
        if (crawlSession == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.service.aggregator.ConfigurationService.saveCrawlSession(com.ten45.entity.aggregation.CrawlSession crawlSession) - 'crawlSession' can not be null");
        }
        try
        {
            this.handleSaveCrawlSession(crawlSession);
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.saveCrawlSession(com.ten45.entity.aggregation.CrawlSession crawlSession)' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #saveCrawlSession(com.ten45.entity.aggregation.CrawlSession)}
      */
    protected abstract void handleSaveCrawlSession(com.ten45.entity.aggregation.CrawlSession crawlSession)
        throws java.lang.Exception;

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#discoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl>)
     */
    public java.lang.Long discoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> crawlSessions)
    {
        if (crawlSessions == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.service.aggregator.ConfigurationService.discoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> crawlSessions) - 'crawlSessions' can not be null");
        }
        try
        {
            return this.handleDiscoverCrawlSessions(crawlSessions);
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.discoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> crawlSessions)' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #discoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl>)}
      */
    protected abstract java.lang.Long handleDiscoverCrawlSessions(java.util.List<com.ten45.entity.aggregation.CrawlSessionImpl> crawlSessions)
        throws java.lang.Exception;

    /**
     * @see com.ten45.service.aggregator.ConfigurationService#clearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession)
     */
    public void clearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession crawlSession)
    {
        if (crawlSession == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.service.aggregator.ConfigurationService.clearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession crawlSession) - 'crawlSession' can not be null");
        }
        try
        {
            this.handleClearCrawlSessionElements(crawlSession);
        }
        catch (Throwable th)
        {
            throw new com.ten45.service.aggregator.ConfigurationServiceException(
                "Error performing 'com.ten45.service.aggregator.ConfigurationService.clearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession crawlSession)' --> " + th,
                th);
        }
    }

     /**
      * Performs the core logic for {@link #clearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession)}
      */
    protected abstract void handleClearCrawlSessionElements(com.ten45.entity.aggregation.CrawlSession crawlSession)
        throws java.lang.Exception;

    /**
     * Gets the current <code>principal</code> if one has been set,
     * otherwise returns <code>null</code>.
     *
     * @return the current principal
     */
    protected java.security.Principal getPrincipal()
    {
        return com.ten45.PrincipalStore.get();
    }
}