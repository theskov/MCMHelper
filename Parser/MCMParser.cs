using System.Collections.Generic;
using HtmlAgilityPack;
using System.Web;
using HttpUtils;
using Parser;
using Shared.DataClasses;
using Shared.Interfaces;


namespace MCMParser
{
    public class MCMParser : IParser
    {
        private HtmlDocument doc = new HtmlDocument();
        public bool Initialize(string url)
        {
            PageFetcher.GetHtmlPage(PathConstants.BaseUrl);
            return true;
        }

        public bool GotoSearchPage()
        {
            throw new System.NotImplementedException();
        }

        public bool SearchForSellers(string cardName)
        {
            string urlEncoded = HttpUtility.UrlEncode(cardName);
            string searchUrl = PathConstants.BaseUrl + string.Format(PathConstants.SearchPage, urlEncoded);
            doc.LoadHtml(PageFetcher.GetHtmlPage(searchUrl));
            return true;
        }

        public bool ChooseResult()
        {
            throw new System.NotImplementedException();
        }

        public bool SeeForAllExpansions()
        {
            throw new System.NotImplementedException();
        }

        public List<CardOffer> GetOfferList()
        {
            throw new System.NotImplementedException();
        }

        public bool GotoNextResultPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
