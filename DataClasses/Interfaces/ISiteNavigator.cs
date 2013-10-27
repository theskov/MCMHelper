using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataClasses;

namespace Shared.Interfaces
{
    public interface ISiteNavigator<T> where T : IParser
    {
        IEnumerable<CardOffer> FindSellers(CardWish cardWish);
    }
}
