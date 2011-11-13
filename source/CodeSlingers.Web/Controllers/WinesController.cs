using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSlingers.Web.Models;
using CodeSlingers.Web.Data;
using CodeSlingers.Web.Services;

namespace CodeSlingers.Web.Controllers
{
    public class WinesController : Controller
    {
        private readonly IFourSquareApi _fourSquareApi;

        public WinesController(IFourSquareApi fourSquareApi)
        {
            _fourSquareApi = fourSquareApi;
        }

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

                Business businessOwner = _fourSquareApi.GetVenueById(businessId);
                foreach (var wineId in business.WineIds)
                {
                    var wine = session.Load<Wine>(wineId);
                    if (wine != null)
                    {
                        wine.BusinessOwner = businessOwner;
                        wines.Add(wine);
                    }
                }
            }
            return Json(wines, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ById(int wineId)
        {
            Wine wine;
            string businessId;
            using (var session = Db.CreateSession())
            {
                wine = session.Load<Wine>(wineId);
                var id = "wines/" + wineId;
                businessId = session.Query<WineBusiness>().ToList().Where(wb => wb.WineIds.Contains(id)).FirstOrDefault().Id;
            }
            if (wine == null)
            {
                Response.StatusCode = 404;
                return Json("Wine not found", JsonRequestBehavior.AllowGet);
            }

            wine.BusinessOwner = _fourSquareApi.GetVenueById(businessId);
            return Json(wine, JsonRequestBehavior.AllowGet);
        }

    }
}
