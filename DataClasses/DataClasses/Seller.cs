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
        public int Transactions;
        public SellerRating Rating;
        public IEnumerable<SellerAttributes> Attributes;
        public decimal LossPercentage;
    }

    public enum SellerRating
    {
        Bad,
        Average,
        Good,
        VeryGood,
        Outstanding
    }

    public enum SellerAttributes
    {
        VeryFastShipping,
        FastShipping,
        UntrackedNotEligible,
        UntrackedOnlyUpTo10,
        Professional,
        FreeFoil
    }

}
