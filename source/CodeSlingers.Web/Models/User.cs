using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSlingers.Web.Models
{
    public class User
    {
        public User()
        {
            WineIds = new List<string>();
        }
        public long Id { get; set; }

        public IList<string> WineIds { get; set; }

        public void AddWine(int wineId)
        {
            this.WineIds.Add("wines/" + wineId);
        }
    }
}