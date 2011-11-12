using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models
{
    public class Wine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Varietal { get; set; }

        public int Year { get; set; }

        public string PhotoPath { get; set; }

        public string Vineyard { get; set; }

        public WineType Type { get; set; }

        public string Country { get; set; }
    }
}