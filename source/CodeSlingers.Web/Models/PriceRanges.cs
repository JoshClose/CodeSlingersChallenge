using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSlingers.Web.Models
{
    public static class PriceRanges
    {
        static PriceRanges()
        {
            UnderTwentyFive = "Under $25";
            TwentyFiveToFifty = "$25 - $50";
            FiftyToOneHundred = "$50 - $100";
            OverOneHundred = "Over $100";
        }

        public static string UnderTwentyFive { get; private set; }
        public static string TwentyFiveToFifty { get; private set; }
        public static string FiftyToOneHundred { get; private set; }
        public static string OverOneHundred { get; private set; }

    }
}