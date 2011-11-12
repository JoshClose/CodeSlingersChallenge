using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models.Contracts
{
    public class FourSquareGroup
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<FourSquareItem> Items { get; set; }
    }
}