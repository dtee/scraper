// license-header java merge-point
//
// Attention: Generated code! Do not modify by hand!
// Generated by: DefaultServiceException.vsl in andromda-spring-cartridge.
//
package com.ten45.manager.aggregator;

/**
 * The default exception thrown for unexpected errors occurring
 * within {@link com.ten45.manager.aggregator.CrawlManager}.
 */
@SuppressWarnings("serial")
public class CrawlManagerException
    extends com.ten45.basic.KeyedException
{

    /**
     */
    public CrawlManagerException( Key key )
    {
        super( key );
    }

    /**
     */
    public CrawlManagerException( Key key, Throwable t )
    {
        super( key, t );
    }

    /**
     */
    public CrawlManagerException( Key key, Object[] arguments )
    {
        super( key, arguments );
    }

    /**
     */
    public CrawlManagerException( Key key, Object[] arguments, Throwable t )
    {
        super( key, arguments, t );
    }

    /**
     * Constructs a new instance of <code>CrawlManagerException</code>.
     *
     * @param throwable the parent Throwable
     */
    public CrawlManagerException(Throwable throwable)
    {
        super(findRootCause(throwable));
    }

    /**
     * Constructs a new instance of <code>CrawlManagerException</code>.
     *
     * @param message the throwable message.
     */
    public CrawlManagerException(String message)
    {
        super(message);
    }

    /**
     * Constructs a new instance of <code>CrawlManagerException</code>.
     *
     * @param message the throwable message.
     * @param throwable the parent of this Throwable.
     */
    public CrawlManagerException(String message, Throwable throwable)
    {
        super(message, findRootCause(throwable));
    }

}