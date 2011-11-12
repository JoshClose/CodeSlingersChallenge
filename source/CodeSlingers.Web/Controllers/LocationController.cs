using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeSlingers.Web.Controllers
{
    public class LocationController : Controller
    {
        public ActionResult NearbyBusinesses(decimal latitude, decimal longitude)
        {
            return View();
        }

    }
}
