using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models
{
    public static class RedVarietals
    {
        static RedVarietals()
        {
            CabSav = "Cabernet Sauvignon";
            Merlot = "Merlot";
        }

        public static string CabSav { get; private set; }
        public static string Merlot { get; private set; }
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
    }
}