using System;
using System.Collections.Generic;
using Shared.DataClasses;
using Shared.Interfaces;

namespace MCMSiteNavigator
{
    public class SiteNavigator : ISiteNavigator<IParser>
    {
        public SiteNavigator(IParser parser)
        {
            this.parser = parser;
        }
        public IParser parser;

        public IEnumerable<CardOffer> FindSellers(CardWish cardWish)
        {
            parser.Initialize("");
            parser.SearchForSellers(cardWish.Name);
            parser.ChooseResult();
            parser.SeeForAllExpansions();
            return parser.GetOfferList();
        }
    }
}
