using System.IO;
using System.Net;
using System.Text;

namespace HttpUtils
{
    public class PageFetcher
    {
        private static PageFetcher instance;
        private CookieContainer cookieContainer;

        private PageFetcher()
        {
            cookieContainer = new CookieContainer();
        }

        private static PageFetcher Instance
        {
            get { return instance ?? (instance = new PageFetcher()); }
        }
        
        public static string GetHtmlPage(string url)
        {
            // Try two times, to enable setting SessionID in the first attempt
            for (int i = 0; i < 2; i++)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent =
                    "User-Agent: Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
                request.CookieContainer = Instance.cookieContainer;
            
                // For HTTP, cast the request to HttpWebRequest
                // allowing setting more properties, e.g. User-Agent.
                // An HTTP response can be cast to HttpWebResponse.
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        // Ensure that the correct encoding is used. 
                        // Check the response for the Web server encoding.
                        // For binary content, use a stream directly rather
                        // than wrapping it with StreamReader.

                        using (StreamReader reader = new StreamReader
                            (response.GetResponseStream(), Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                            // process the content
                        }
                    }
                }
                catch (WebException we)
                {
                    
                }
            }
            return null;
        }
    }
}
