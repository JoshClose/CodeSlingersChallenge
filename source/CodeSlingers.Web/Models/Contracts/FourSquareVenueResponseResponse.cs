﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeSlingers.Web.Models.Contracts
{
    public class FourSquareVenueResponseResponse
    {
        public IList<FourSquareGroup> Groups { get; set; }
    }
}