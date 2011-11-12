using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models.Contracts
{
    public class FourSquareLocation
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CrossStreet { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public int Distance { get; set; }
        public int ZipCode { get; set; }
    }
}