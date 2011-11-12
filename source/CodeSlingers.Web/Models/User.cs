using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models
{
    public class User
    {
        public long Id { get; set; }

        public IList<Wine> Wines { get; set; }
    }
}