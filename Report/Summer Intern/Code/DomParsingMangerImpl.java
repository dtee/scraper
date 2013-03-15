// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.manager.aggregator;

import java.io.StringReader;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;

/**
 * @see com.ten45.manager.aggregator.DomParsingManger
 */
public class DomParsingMangerImpl
    extends com.ten45.manager.aggregator.DomParsingMangerBase
{

    /**
     * @see com.ten45.manager.aggregator.DomParsingManger#getDocument(java.lang.String)
     */
    protected org.w3c.dom.Document handleGetDocument(java.lang.String htmlData)
        throws java.lang.Exception
    {
        //@todo implement protected org.w3c.dom.Document handleGetDocument(java.lang.String htmlData)
        org.cyberneko.html.parsers.DOMParser domParser = new org.cyberneko.html.
        parsers.DOMParser();
        domParser.setFeature(
                "http://apache.org/xml/features/dom/include-ignorable-whitespace", false);
        
        domParser.setProperty(
                "http://cyberneko.org/html/properties/names/elems", "lower");
        
        StringReader stringReader = new StringReader(htmlData);
        InputSource inputSource = new InputSource(stringReader);
        domParser.parse(inputSource);
        Document document = domParser.getDocument();
        
        return document;
    }

}