using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models.Contracts
{
    public class FourSquareItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public FourSquareLocation Location { get; set; }
        public List<FourSquareCategory> Categories { get; set; }
        public FourSquareContact Contact { get; set; }
    }
}