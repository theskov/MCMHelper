using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Web;
using HttpUtils;
using Parser;
using Shared.DataClasses;
using Shared.Interfaces;
using System.Linq;

namespace MCMParser
{
    public class MCMParser : IParser
    {
        private HtmlDocument doc = new HtmlDocument();
        private string cardName;

        private static Regex ExpansionRegEx = new Regex(@"showMsgBox\('([^']*)'\)");
        private static Regex LanguageRegEx = ExpansionRegEx;
        private static Regex NationalityRegEx = new Regex(@"showMsgBox\('Item location: ([^']*)'\)");
        private static Regex TransactionsRegEx = new Regex(@"\(([^\)]*)\)");

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
            this.cardName = cardName;
            string urlEncoded = HttpUtility.UrlEncode(cardName);
            string searchUrl = PathConstants.BaseUrl + string.Format(PathConstants.SearchPage, urlEncoded);
            doc.LoadHtml(PageFetcher.GetHtmlPage(searchUrl));
            return true;
        }

        public bool ChooseResult()
        {
            var resultLink = doc.DocumentNode.SelectSingleNode(string.Format("//a[text()='{0}']", cardName)).Attributes["href"].Value;
            doc.LoadHtml(PageFetcher.GetHtmlPage(PathConstants.BaseUrl + resultLink));
            return true;
        }

        public bool SeeForAllExpansions()
        {
            var resultLink = doc.DocumentNode.SelectSingleNode(string.Format("//a[text()='{0}']", "See cards from all expansions")).Attributes["href"].Value;
            resultLink = resultLink.Substring(1, resultLink.Length - 1); // Remove leading '/'
            resultLink = HttpUtility.HtmlDecode(resultLink);
            doc.LoadHtml(PageFetcher.GetHtmlPage(PathConstants.BaseUrl + resultLink));
            return true;
        }

        public List<CardOffer> GetOfferList()
        {
            var result = new List<CardOffer>();
            var results = doc.DocumentNode.SelectNodes(string.Format("//table[@class='{0}']//tr", "MKMTable specimenTable"));

            // TODO Filter list - fx by not including too expensive offers or by taking next pages as well
            foreach (var sellerOfferRow in results)
            {
                var columns = sellerOfferRow.SelectNodes(sellerOfferRow.XPath + "//td");
                if (columns == null || columns.Count < 9) continue; // The header has th elements instead of td elements. Footer has just one td element.

                var quantityString = columns[9].InnerHtml.Contains('<')
                                   ? columns[9].InnerHtml.Substring(0, columns[9].InnerHtml.IndexOf('<'))
                                   : columns[9].InnerHtml;
                var cardOffer = new CardOffer()
                    {
                        Card = new Card()
                            {
                                Expansion = ExpansionRegEx.Match(columns[2].InnerHtml).Groups[1].Value,
                                Foil = columns[6].InnerHtml.ToLower().Contains("foil"),
                                Language = LanguageRegEx.Match(columns[4].InnerHtml).Groups[1].Value,
                                Name = cardName,
                                // TODO Map quality string to enum: Quality = columns[7]...
                            },
                        Price = decimal.Parse(columns[8].InnerHtml.Substring(0, columns[8].InnerHtml.IndexOf(' '))),
                        Quantity = int.Parse(quantityString.Trim(new [] { '"' })),
                        Seller = new Seller()
                            {
                                Name = columns[1].ChildNodes[0].Descendants("a").First().InnerText,
                                Nationality =
                                    NationalityRegEx.Match(columns[1].ChildNodes[0].ChildNodes[3].InnerHtml).Groups[1]
                                        .Value,
                                //Rating = TODO Map rating string to enum
                                Transactions =
                                    int.Parse(
                                        TransactionsRegEx.Match(columns[1].ChildNodes[0].ChildNodes[1].InnerHtml).Groups[1].Value),
                                // Attributes = TODO Map attribute strings to enum
                            }
                    };
                result.Add(cardOffer);
            }
            return result;
        }

        public bool GotoNextResultPage()
        {
            throw new System.NotImplementedException();
        }
    }
}
