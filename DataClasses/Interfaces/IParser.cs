using System.Collections.Generic;
using Shared.DataClasses;

namespace Shared.Interfaces
{
    public interface IParser
    {
        bool Initialize(string url);
        bool GotoSearchPage();
        bool SearchForSellers(string cardName);
        bool ChooseResult();
        bool SeeForAllExpansions();
        List<CardOffer> GetOfferList();
        bool GotoNextResultPage();
    }
}
