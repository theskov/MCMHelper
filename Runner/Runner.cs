using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataClasses;
using Shared.Interfaces;

namespace Runner
{
    public class Runner : IRunner
    {
        private ISiteNavigator<IParser> navigator;
        public Runner(ISiteNavigator<IParser> navigator)
        {
            this.navigator = navigator;
        }

        public IEnumerable<string> GetSellerList(string cardName)
        {
            return navigator.FindSellers(new CardWish() { Name = cardName }).Select(co => co.Seller.Name);
        }
    }
}
