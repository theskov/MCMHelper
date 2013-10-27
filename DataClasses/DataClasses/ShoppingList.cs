using System.Collections.Generic;

namespace Shared.DataClasses
{
    public struct ShoppingList
    {
        public IEnumerable<CardWish> CardWishes;
        public IEnumerable<Quality> Qualities;
        public IEnumerable<string> Languages;
        public bool? Foil;
    }
}
