// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.manager.aggregator;

import java.util.LinkedList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.ten45.basic.Log;
import com.ten45.domain.crawler.AttributeType;

/**
 * @see com.ten45.manager.aggregator.DataRefiningManager
 */
public class DataRefiningManagerImpl
    extends com.ten45.manager.aggregator.DataRefiningManagerBase
{

    /**
     * @see com.ten45.manager.aggregator.DataRefiningManager#refineData(java.lang.String, int)
     */
    protected java.lang.Object handleRefineData(java.lang.String dataString, int dataTypeEnum)
        throws java.lang.Exception
    {
        Object dataObj = dataString;
        try {
            if (dataTypeEnum == AttributeType.DataType.INT_INT) {
                dataObj = this.parseInt(dataString);
            }
            else if (dataTypeEnum == AttributeType.DataType.INT_STRING) {
                //entity.setEntityAttribute(a.getAttributeName(), dataString);    
                // Perform croping
            }
            else if (dataTypeEnum == AttributeType.DataType.INT_DATE) {
                throw new Exception("Date dataype not yet implemented");                    
            }
            else if (dataTypeEnum == AttributeType.DataType.INT_FLOAT) {
                dataObj = this.parseDouble(dataString);             
            }
            else if (dataTypeEnum == AttributeType.DataType.INT_MONEY) {
                // Parse money
                dataObj = this.parseMoney(dataString);                 
            }
            else if (dataTypeEnum == AttributeType.DataType.INT_URL) {
                // don't have much to do.. we can look for url pattern?
                // We can try to read java scripted urls" ie: getUrl('quote')                    
            }
        }
        catch (Exception ex) {
            log.debug (ex.getMessage());
            log.debug (ex.getStackTrace());
        }
        
        return dataObj;
    }
    
    /***
     * Regular expression match takes a list of pattern and match them in order
     * @param data 
     *          Data string to match
     * @param patterns 
     *          List of regex pattern to match on the data string
     * @return
     *          string with the matched pattern.
     */
    private String regexMatch(String data, List<String> patterns) {
        String str = "";
        for (String p: patterns) {
            Pattern patt = Pattern.compile(p);
            Matcher m = patt.matcher(data);

            if (m.find()) {
                str = m.group().toString();
                break;
            }
        }

        return str;
    }

    /**
     * Parse a string that contains money
     * @param data
     *      string containing money
     * @return
     *      money represnted in double.
     */
    private double parseMoney(String data) {
        List<String> patterns = new LinkedList<String>();
        patterns.add("\\$(\\d+\\.\\d+)");

        return parseDouble(this.regexMatch(data, patterns));
    }

    /**
     * Parse a string containing double data type
     * @param data
     *      String containing double
     * @return
     *      first double matched on the string
     */
    private double parseDouble(String data) {
        List<String> patterns = new LinkedList<String>();
        patterns.add("\\d+\\.\\d+");

        double dataDouble = Double.parseDouble(this.regexMatch(data, patterns));

        return dataDouble;
    }

    /**
     * Parse a string containing an integer
     * @param data
     *      String that contains an integer
     * @return
     *      first integer matched on the string
     */
    private int parseInt(String data) {
        List<String> patterns = new LinkedList<String>();
        patterns.add("\\d+");

        int dataInt = Integer.parseInt(this.regexMatch(data, patterns));

        return dataInt;
    }

    Log log = Log.getInstance(this.getClass());
}