using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CodeSlingers.WP7.App.Models
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
