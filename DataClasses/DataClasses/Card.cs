using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataClasses
{
    public struct Card
    {
        public string Name;
        public string Language;
        public string Expansion;
        public Quality Quality;
        public bool Foil;
    }

    public enum Quality
    {
        Poor,
        Played,
        LightPlayed,
        Good,
        Excellent,
        NearMint,
        Mint
    }
}
