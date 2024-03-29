// license-header java merge-point
//
// Attention: Generated code! Do not modify by hand!
// Generated by: SpringHibernateDaoBase.vsl in andromda-spring-cartridge.
//
package com.ten45.entity.aggregation;

/**
 * <p>
 * Base Spring DAO Class: is able to create, update, remove, load, and find
 * objects of type <code>com.ten45.entity.aggregation.CrawlSession</code>.
 * </p>
 *
 * @see com.ten45.entity.aggregation.CrawlSession
 */
public abstract class CrawlSessionDaoBase
    extends com.ten45.entity.EntityDaoImpl
    implements com.ten45.entity.aggregation.CrawlSessionDao
{


    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(int, java.lang.Long)
     */
    public Object load(final int transform, final java.lang.Long id)
    {
        if (id == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.load - 'id' can not be null");
        }
        final java.util.List list = this.getHibernateTemplate().find(
            "from com.ten45.entity.aggregation.CrawlSession as entity where entity.id = ?", id);
        final Object entity = list != null && !list.isEmpty() ? list.iterator().next() : null;
        return transformEntity(transform, (com.ten45.entity.aggregation.CrawlSession)entity);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(int, java.lang.Long[])
     */
    public java.util.List load(final int transform, final java.lang.Long[] id)
    {
        if (com.ten45.basic.util.CollectionUtil.isEmpty(id))
        {
            throw new IllegalArgumentException(
                "CrawlSession.load - 'id' can not be null");
        }
        org.hibernate.Query query = getSession().createQuery("from com.ten45.entity.aggregation.CrawlSession as entity where entity.id in ( :idList )");
        query.setParameterList("idList", id);
        final java.util.List<com.ten45.entity.aggregation.CrawlSession> list = query.list();
        transformEntities(transform, list);
        return list;
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(int, java.lang.Long[])
     */
    public java.util.List load(final int transform, final java.util.Collection<java.lang.Long> id)
    {
        if (com.ten45.basic.util.CollectionUtil.isEmpty(id))
        {
            throw new IllegalArgumentException(
                "CrawlSession.load - 'id' can not be null");
        }
        org.hibernate.Query query = getSession().createQuery("from com.ten45.entity.aggregation.CrawlSession as entity where entity.id in ( :idList )");
        query.setParameterList("idList", id);
        final java.util.List<com.ten45.entity.aggregation.CrawlSession> list = query.list();
        transformEntities(transform, list);
        return list;
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(java.lang.Long)
     */
    public com.ten45.entity.aggregation.CrawlSession load(java.lang.Long id)
    {
        return (com.ten45.entity.aggregation.CrawlSession)this.load(TRANSFORM_NONE, id);
    }
    
    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(java.lang.Long[])
     */
    public java.util.List load(java.lang.Long[] id)
    {
        return this.load(TRANSFORM_NONE, id);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#load(java.util.Collection<java.lang.Long>)
     */
    public java.util.List load(java.util.Collection<java.lang.Long> id)
    {
        return this.load(TRANSFORM_NONE, id);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#loadAll()
     */
    public java.util.Collection loadAll()
    {
        return this.loadAll(TRANSFORM_NONE);
    }
    
    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#loadAll(int)
     */
    public java.util.Collection loadAll(final int transform)
    {
        final java.util.Collection results = this.getHibernateTemplate().loadAll(com.ten45.entity.aggregation.CrawlSessionImpl.class);
        this.transformEntities(transform, results);
        return results;
    }
    
    /**
      * @see com.ten45.entity.aggregation.CrawlSessionDao#loadByCriteria(org.hibernate.criterion.DetachedCriteria)
      */
    public java.util.List loadByCriteria(org.hibernate.criterion.DetachedCriteria criteria)
    {
        return this.getHibernateTemplate().findByCriteria(criteria);
    }
    
    

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#create(com.ten45.entity.aggregation.CrawlSession)
     */
    public com.ten45.entity.aggregation.CrawlSession create(com.ten45.entity.aggregation.CrawlSession crawlSession)
    {
        return (com.ten45.entity.aggregation.CrawlSession)this.createEntity( crawlSession);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#create(java.lang.Integer, java.net.URL, java.lang.Integer, java.util.Date, java.util.Date, java.lang.Integer, java.lang.Long)
     */
    public com.ten45.entity.aggregation.CrawlSession create(
        java.lang.Integer errorCount,
        java.net.URL siteUrl,
        java.lang.Integer successCount,
        java.util.Date endDate,
        java.util.Date startDate,
        java.lang.Integer crawlType,
        java.lang.Long feedID)
    {
        return (com.ten45.entity.aggregation.CrawlSession)this.create(TRANSFORM_NONE, errorCount, siteUrl, successCount, endDate, startDate, crawlType, feedID);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#create(int, java.lang.Integer, java.net.URL, java.lang.Integer, java.util.Date, java.util.Date, java.lang.Integer, java.lang.Long)
     */
    public Object create(
        final int transform,
        java.lang.Integer errorCount,
        java.net.URL siteUrl,
        java.lang.Integer successCount,
        java.util.Date endDate,
        java.util.Date startDate,
        java.lang.Integer crawlType,
        java.lang.Long feedID)
    {
        com.ten45.entity.aggregation.CrawlSession entity = new com.ten45.entity.aggregation.CrawlSessionImpl();
        entity.setErrorCount(errorCount);
        entity.setSiteUrl(siteUrl);
        entity.setSuccessCount(successCount);
        entity.setEndDate(endDate);
        entity.setStartDate(startDate);
        entity.setCrawlType(crawlType);
        entity.setFeedID(feedID);
        return this.create(transform, entity);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#create(java.lang.Integer, java.lang.Integer, com.ten45.entity.common.AbstractMerchant, java.net.URL, java.lang.Integer)
     */
    public com.ten45.entity.aggregation.CrawlSession create(
        java.lang.Integer crawlType,
        java.lang.Integer errorCount,
        com.ten45.entity.common.AbstractMerchant merchant,
        java.net.URL siteUrl,
        java.lang.Integer successCount)
    {
        return (com.ten45.entity.aggregation.CrawlSession)this.create(TRANSFORM_NONE, crawlType, errorCount, merchant, siteUrl, successCount);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#create(int, java.lang.Integer, java.lang.Integer, com.ten45.entity.common.AbstractMerchant, java.net.URL, java.lang.Integer)
     */
    public Object create(
        final int transform,
        java.lang.Integer crawlType,
        java.lang.Integer errorCount,
        com.ten45.entity.common.AbstractMerchant merchant,
        java.net.URL siteUrl,
        java.lang.Integer successCount)
    {
        com.ten45.entity.aggregation.CrawlSession entity = new com.ten45.entity.aggregation.CrawlSessionImpl();
        entity.setCrawlType(crawlType);
        entity.setErrorCount(errorCount);
        entity.setMerchant(merchant);
        entity.setSiteUrl(siteUrl);
        entity.setSuccessCount(successCount);
        return this.create(transform, entity);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#update(com.ten45.entity.aggregation.CrawlSession)
     */
    public void update(com.ten45.entity.aggregation.CrawlSession crawlSession)
    {
        if (crawlSession == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.update - 'crawlSession' can not be null");
        }
        this.getHibernateTemplate().update(crawlSession);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#update(java.util.Collection)
     */
    public void update(final java.util.Collection entities)
    {
        if (entities == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.update - 'entities' can not be null");
        }
        this.getHibernateTemplate().execute(
            new org.springframework.orm.hibernate3.HibernateCallback()
            {
                public Object doInHibernate(org.hibernate.Session session)
                    throws org.hibernate.HibernateException
                {
                    for (java.util.Iterator entityIterator = entities.iterator(); entityIterator.hasNext();)
                    {
                        update((com.ten45.entity.aggregation.CrawlSession)entityIterator.next());
                    }
                    return null;
                }
            },
            true);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#remove(com.ten45.entity.aggregation.CrawlSession)
     */
    public void remove(com.ten45.entity.aggregation.CrawlSession crawlSession)
    {
        if (crawlSession == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.remove - 'crawlSession' can not be null");
        }
        this.getHibernateTemplate().delete(crawlSession);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#remove(java.lang.Long)
     */
    public void remove(java.lang.Long id)
    {
        if (id == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.remove - 'id' can not be null");
        }
        com.ten45.entity.aggregation.CrawlSession entity = this.load(id);
        if (entity != null)
        {
            this.remove(entity);
        }
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#remove(java.util.Collection)
     */
    public void remove(java.util.Collection entities)
    {
        if (entities == null)
        {
            throw new IllegalArgumentException(
                "CrawlSession.remove - 'entities' can not be null");
        }
        this.getHibernateTemplate().deleteAll(entities);
    }

    /**
     * @see com.ten45.entity.aggregation.CrawlSessionDao#findCrawlSession(java.net.URL)
     */
    public com.ten45.entity.aggregation.CrawlSession findCrawlSession(final java.net.URL siteUrl)
    {
        if (siteUrl == null)
        {
            throw new IllegalArgumentException(
                "com.ten45.entity.aggregation.CrawlSessionDao.findCrawlSession(java.net.URL siteUrl) - 'siteUrl' can not be null");
        }
        try
        {
            return this.handleFindCrawlSession(siteUrl);
        }
        catch (Throwable th)
        {
            throw new java.lang.RuntimeException(
            "Error performing 'com.ten45.entity.aggregation.CrawlSessionDao.findCrawlSession(java.net.URL siteUrl)' --> " + th,
            th);
        }
    }

     /**
      * Performs the core logic for {@link #findCrawlSession(java.net.URL)}
      */
    protected abstract com.ten45.entity.aggregation.CrawlSession handleFindCrawlSession(java.net.URL siteUrl)
        throws java.lang.Exception;


}