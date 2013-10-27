using System.Collections.Generic;

namespace Shared.DataClasses
{
    public struct CardWish
    {
        public string Name;
        public int Quantity;
        public IEnumerable<string> Expansions;
        public IEnumerable<Quality> Qualities;
        public IEnumerable<string> Languages;
        public bool? Foil;
    }
}
