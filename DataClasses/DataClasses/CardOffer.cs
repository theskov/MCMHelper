using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataClasses
{
    public struct CardOffer
    {
        public Seller Seller;
        public Card Card;
        public int Quantity;
        public decimal Price;
    }
}
