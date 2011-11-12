using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeSlingers.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }

        public ActionResult OAuthCallback()
        {
            return View();
        }
    }
}