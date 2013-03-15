// license-header java merge-point
//
// Attention: Generated code! Do not modify by hand!
// Generated by: SpringService.vsl in andromda-spring-cartridge.
//
package com.ten45.service.aggregator;

/**
 * 
 */
public interface CrawlDeDupService
{

    /**
     * 
     */
    public com.ten45.domain.crawler.DeDupInfo deDupCategories(java.util.List<com.ten45.entity.product.ProductCategory> categories);

    /**
     * 
     */
    public com.ten45.domain.crawler.DeDupInfo deDupProducts(java.util.List<com.ten45.entity.online.OnlineProduct> products);

    /**
     * 
     */
    public void loadChecksum(com.ten45.entity.common.AbstractMerchant merchant, java.lang.String productIdAttributeName);

    /**
     * <p>
     * Unload the merchant checksum stuffs from memory
     * </p>
     */
    public void unLoadChecksum(com.ten45.entity.common.AbstractMerchant merchant);


    static final com.ten45.basic.Log log = com.ten45.basic.Log.getInstance( CrawlDeDupService.class );

}
