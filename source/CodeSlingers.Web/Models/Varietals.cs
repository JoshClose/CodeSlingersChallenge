using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace CodeSlingers.Web.Models
{
    public static class VarietalsHelper
    {
        public static ObservableCollection<string> GetVarietalsListByWineType(string wineType)
        {
            string name = wineType.ToLower();
            ObservableCollection<string> varietals = null;

            if (name == "red")
            {
                varietals = RedVarietals.GetAllVarietals();
            }
            else if (name == "white")
            {
                varietals = WhiteVarietals.GetAllVarietals();
            }
            else if (name == "rose")
            {
                varietals = RoseVarietals.GetAllVarietals();
            }
            else if (name == "dessert")
            {
                varietals = DessertVarietals.GetAllVarietals();
            }
            else
            {
                //default to red
                varietals = RedVarietals.GetAllVarietals();
            }

            return varietals;
        }
    }

    public static class RedVarietals
    {
        static RedVarietals()
        {
            CabSav = "Cabernet Sauvignon";
            Merlot = "Merlot";
        }

        public static string CabSav { get; private set; }
        public static string Merlot { get; private set; }

        public static ObservableCollection<string> GetAllVarietals()
        {
            return new ObservableCollection<string> { CabSav, Merlot };
        }
    }

    public static class WhiteVarietals
    {
        static WhiteVarietals()
        {
            PinotGrigio = "Pinot Grigio";
            Riesling = "Riesling";
        }

        public static string PinotGrigio { get; private set; }
        public static string Riesling { get; private set; }

        public static ObservableCollection<string> GetAllVarietals()
        {
            return new ObservableCollection<string> { PinotGrigio, Riesling };
        }
    }

    public static class RoseVarietals
    {
        static RoseVarietals()
        {
            WhiteZin = "White Zinfandel";
            MerlotRose = "Merlot Rose";
        }

        public static string WhiteZin { get; private set; }
        public static string MerlotRose { get; private set; }

        public static ObservableCollection<string> GetAllVarietals()
        {
            return new ObservableCollection<string> { WhiteZin, MerlotRose };
        }
    }

    public static class DessertVarietals
    {
        static DessertVarietals()
        {
            Port = "Port";
            Sherry = "Sherry";
        }

        public static string Port { get; private set; }
        public static string Sherry { get; private set; }

        public static ObservableCollection<string> GetAllVarietals()
        {
            return new ObservableCollection<string> { Port, Sherry };
        }
    }
}