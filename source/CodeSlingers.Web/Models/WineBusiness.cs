using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSlingers.Web.Models
{
    public class WineBusiness
    {
        public WineBusiness()
        {
            WineIds = new List<string>();
        }
        public string Id { get; set; }

        public List<string> WineIds { get; set; }

        public void AddWine(int wineId)
        {
            this.WineIds.Add("wines/" + wineId);
        }
    }
}