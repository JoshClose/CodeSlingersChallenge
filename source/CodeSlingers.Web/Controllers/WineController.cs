using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeSlingers.Web.Controllers
{
    public class WineController : Controller
    {
        //
        // GET: /Wine/

        public ActionResult My(string facebookAuthToken, long facebookId)
        {
            return View();
        }

    }
}
