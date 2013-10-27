using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataClasses
{
    public struct Seller
    {
        public string Name;
        public string Nationality;
        public SellerRating Rating;
    }

    public enum SellerRating
    {
        Bad,
        Average,
        Good,
        VeryGood,
        Outstanding
    }
}
