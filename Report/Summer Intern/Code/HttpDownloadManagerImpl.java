// license-header java merge-point
/**
 * This is only generated once! It will never be overwritten.
 * You can (and have to!) safely modify it by hand.
 */
package com.ten45.manager.aggregator;

import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.nio.charset.Charset;
import java.util.zip.GZIPInputStream;

import org.apache.commons.httpclient.Cookie;
import org.apache.commons.httpclient.Header;
import org.apache.commons.httpclient.HostConfiguration;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpMethod;
import org.apache.commons.httpclient.MultiThreadedHttpConnectionManager;
import org.apache.commons.httpclient.cookie.CookiePolicy;
import org.apache.commons.httpclient.methods.GetMethod;
import org.apache.commons.httpclient.methods.PostMethod;
import org.apache.commons.httpclient.params.HttpClientParams;

import com.ten45.basic.util.IOUtil;
import com.ten45.basic.util.StringUtil;

/**
 * @see com.ten45.manager.aggregator.HttpDownloadManager
 */
public class HttpDownloadManagerImpl
    extends com.ten45.manager.aggregator.HttpDownloadManagerBase
{
    /**
     * @see com.ten45.manager.aggregator.HttpDownloadService#getData(java.net.URL)
     */
    protected java.lang.String handleGetData(java.net.URL Url)
        throws java.lang.Exception
    {
        String data = getInputHttpSource(Url, null, true, true);
        return data;
    }

    private final static int DefaultTimeout = 1000 * 30;
    private final static int RetryLimitation = 5;
    private final static int SuccessCode = 200;
    private Cookie[] m_cookies = null;
    protected String m_charSet = null;

    private final static Charset DefaultCharset = Charset.forName(
            "windows-1252");
    private final static String CharsetString = "charset";

    private HttpMethod getMethod(URL url, String response, boolean useCookie,
                                 boolean retryError) throws IOException {
        int numOfRetries = 0;
        int code = 0;
        IOException lastEx = null;

        MultiThreadedHttpConnectionManager multiThreadedHttpConnectionManager = new
                MultiThreadedHttpConnectionManager();

        HttpClientParams httpClientParams = new HttpClientParams();
        httpClientParams.setConnectionManagerTimeout(DefaultTimeout);
        HttpClient m_httpClient = new HttpClient(httpClientParams,
                multiThreadedHttpConnectionManager);
        //m_httpClient.setConnectionTimeout(DefaultTimeout);

        HostConfiguration hostConfiguration = new HostConfiguration();
        while (numOfRetries < RetryLimitation) {
            if (Thread.interrupted()) {
                throw new java.io.InterruptedIOException();
            }

            try {
                hostConfiguration.setHost(url.getHost(), url.getPort(), "http");
                //setProxy(hostConfiguration, url);

                HttpMethod method = null;
                if (!StringUtil.isEmpty(response)) {
                    PostMethod postMethod = new PostMethod(url.toString());
                    postMethod.setRequestHeader("Content-Length",
                                                Integer.
                                                toString(response.length()));
                    postMethod.setRequestHeader("Content-Type",
                            "application/x-www-form-urlencoded");
                    postMethod.setRequestHeader("Connection", "Keep-Alive");

                    postMethod.setRequestBody(response);
                    method = postMethod;
                } else {
                    GetMethod getMethod = new GetMethod(url.toString());
                    method = getMethod;
                }
                if (useCookie) {
                    setUp(method, url);
                }

                method.getParams().setCookiePolicy(CookiePolicy.
                        BROWSER_COMPATIBILITY);
                m_httpClient.getParams().setBooleanParameter(HttpClientParams.
                        ALLOW_CIRCULAR_REDIRECTS, true);

                // open the connection, get a response and return if successful.
                code = m_httpClient.executeMethod(hostConfiguration, method);
                Header[] headers = method.getResponseHeaders();
                if (useCookie) {
                    m_cookies = m_httpClient.getState().getCookies();
                }
                int maxRedirects = 3;
                URL newURL = url;
                while (code >= 300 && code < 399 && maxRedirects > 0) {
                    method.releaseConnection();
                    maxRedirects--;

                    newURL = getURL(method);
                    method = new GetMethod(newURL.toString());
                    if (useCookie) {
                        setUp(method, newURL);
                    }
                    method.getParams().setCookiePolicy(CookiePolicy.
                            BROWSER_COMPATIBILITY);

                    code = m_httpClient.executeMethod(hostConfiguration, method);
                    if (useCookie) {
                        m_cookies = m_httpClient.getState().getCookies();
                    }
                    headers = method.getResponseHeaders();
                }
                if (code == SuccessCode) {
                    return method;
                }
                //CairoLog.adaptive.info("Redirect code [%s] unknown for site %s", code, m_sitename);
            } catch (java.io.InterruptedIOException inex) {
                throw inex;
            } catch (java.io.IOException ioex) {
                if (!retryError) {
                    throw ioex;
                }
                lastEx = ioex;
                //CairoLog.adaptive.info("Failed with [%s]", ioex.getMessage());
            }
            numOfRetries++;
            int retryTime = (int) Math.pow(numOfRetries, 4);
            try {
                Thread.sleep(1000 * retryTime);
            } catch (InterruptedException e) {
                throw new java.io.InterruptedIOException("waiting interrupted");
            }
        }

        if (lastEx != null) {
            throw lastEx;
        }
        throw new IOException("Failed to get [" + url.toString() + "]");
    }

    private static URL getURL(HttpMethod method) throws IOException {
        URL url = null;
        Header header = method.getResponseHeader("location");
        if (header == null) {
            url = new URL(method.getURI().toString());
        } else {
            String hurl = header.getValue();
            if (hurl.startsWith("http:")) {
                url = new URL(hurl);
            } else if (hurl.startsWith("hhttp")) { // Fix this typo for Mervyns / Scene7
                hurl = hurl.replaceAll("hhttp", "http");
                url = new URL(hurl);
            } else {
                URL methodURL = new URL(method.getURI().toString());
                url = new URL(methodURL, hurl);
            }
        }
        return url;
    }

    private void setUp(HttpMethod method, URL url) throws IOException {
        method.setRequestHeader("Accept-Charset", "ISO-8859-1,utf-8");
        method.setRequestHeader("Referer", url.toString());
        method.setRequestHeader("Accept-Language", "en-us");
        method.setRequestHeader("Accept-Encoding", "gzip,deflate");
        method.setRequestHeader("Accept",
                "text/html,image/gif,image/jpg,image/jpeg,image/pjpeg,*/*");
        method.setRequestHeader("User-Agent",
                "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;" +
                                " .NET CLR 1.0.3705; .NET CLR 1.1.4322)");
        method.setRequestHeader("Host", url.getHost());

        if (!(method instanceof PostMethod) && // Entity enclosing requests cannot be redirected without
            url.getHost().indexOf("scene7") == -1) // user intervention according to RFC 2616.
            method.setFollowRedirects(true); // See http://jakarta.apache.org/commons/httpclient/redirects.html
        // Also, scene7 has a redirect bug we have to manage ourselves

    }

    /**
     *  Access the given url without cookie support.
     *  @param response the form response
     */
    protected String getInputHttpSource(
            URL nexturl,
            String response,
            boolean useCookie,
            boolean retryError) throws IOException {
        String str = null;

        if ("file".equalsIgnoreCase(nexturl.getProtocol())) {
            str = IOUtil.getFile(nexturl.getFile());
        } else {
            HttpMethod method = getMethod(nexturl, response, useCookie,
                                          retryError);
            String contentType = null;
            Header header = method.getResponseHeader("Content-Type");
            if (header != null) {
                contentType = header.toString();
            }

            Charset cs = getCharset(contentType);
            //CairoLog.adaptive.debug("ContentType = %s, Charset = %s", contentType, cs);
            InputStream in = getInputStream(method);
            str = readInputStream(in, cs);
            URL url = getURL(method);
            method.releaseConnection();
        }

        return str;
    }

    protected Charset getCharset(String contentType) {
        int index;
        Charset ret = null;

        if (contentType != null) {
            index = contentType.indexOf(CharsetString);

            if (index != -1) {
                String content = contentType.substring(index +
                        CharsetString.length()).trim();
                if (content.startsWith("=")) {
                    content = content.substring(1).trim();
                    index = content.indexOf(";");
                    if (index != -1) {
                        content = content.substring(0, index);
                    }

                    //remove any double quotes from around charset string
                    if (content.startsWith("\"") && content.endsWith("\"") &&
                        (1 < content.length())) {
                        content = content.substring(1, content.length() - 1);
                    }

                    //remove any single quote from around charset string
                    if (content.startsWith("'") && content.endsWith("'") &&
                        (1 < content.length())) {
                        content = content.substring(1, content.length() - 1);
                    }
                    ret = Charset.forName(content);
                }
            }
        }

        if (ret == null && m_charSet != null) {
            ret = Charset.forName(m_charSet);
        }
        if (ret == null) {
            return DefaultCharset;
        }
        return ret;
    }


    /**
     *  Read the entire input stream given the character set and return the resulting string.
     */
    protected String readInputStream(InputStream in, Charset cs) throws
            IOException {
        StringBuffer buf = new StringBuffer(32000);
        // Store the raw response
        if (cs == null) {
            cs = DefaultCharset;
        }
        InputStreamReader inputStreamReader = new InputStreamReader(in, cs);
        int read;
        while ((read = inputStreamReader.read()) != -1) {
            buf.append((char) read);
        }
        String source = buf.toString();
        return source;
    }

    private InputStream getInputStream(HttpMethod method) throws IOException {
        InputStream in = method.getResponseBodyAsStream();

        // handle gzip encoding
        Header encodingHeader = method.getResponseHeader("content-encoding");
        if (encodingHeader != null) {
            String contentEncoding = encodingHeader.toString();
            //CairoLog.adaptive.debug("ContentEncoding = %s", contentEncoding);
            if (contentEncoding != null &&
                contentEncoding.indexOf("gzip") != -1) {
                in = new GZIPInputStream(in);
            }
        }
        return in;
    }
}