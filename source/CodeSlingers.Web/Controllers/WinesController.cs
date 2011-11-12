using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSlingers.Web.Models;
using CodeSlingers.Web.Data;

namespace CodeSlingers.Web.Controllers
{
    public class WinesController : Controller
    {
        //
        // GET: /Wine/

        public ActionResult ByLocation(string businessId)
        {
            var wines = new List<Wine>();
            using (var session = Db.CreateSession())
            {
                var business = session.Include<WineBusiness>(wb => wb.WineIds).Load<WineBusiness>(businessId);
                if (business == null)
                {
                    Response.StatusCode = 404;
                    return Json("No business found", JsonRequestBehavior.AllowGet);
                }

                foreach (var wineId in business.WineIds)
                {
                    var wine = session.Load<Wine>(wineId);
                    if (wine != null)
                    {
                        wines.Add(wine);
                    }
                }
            }
            return Json(wines, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ById(int wineId)
        {
            Wine w;
            using (var session = Db.CreateSession())
            {
                w = session.Load<Wine>(wineId);
            }
            if (w == null)
            {
                Response.StatusCode = 404;
                return Json("Wine not found", JsonRequestBehavior.AllowGet);
            }
            return Json(w, JsonRequestBehavior.AllowGet);
        }

    }
}
