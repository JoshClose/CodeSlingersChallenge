using System;
using System.Collections.Generic;
using System.Linq;

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

        public string Comments { get; set; }

        public string Pairing { get; set; }

        //Use PriceRanges strings for these values
        public string PriceRange { get; set; }

        public Business BusinessOwner { get; set; }

        public string BusinessId { get; set; }

        public DateTime CreateDate { get; set; }

        public long CreatedByUserId { get; set; }

        public void AddParentBusiness(string businessId)
        {
            this.BusinessId = "businesses/" + businessId;
        }
    }
}