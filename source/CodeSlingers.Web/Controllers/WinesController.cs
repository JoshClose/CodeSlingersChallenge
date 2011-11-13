﻿using System;
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

        [HttpPut]
        public ActionResult Create(Wine wine)
        {
            if(wine == null || wine.BusinessOwner == null || string.IsNullOrEmpty(wine.BusinessOwner.Id))
            {
                throw new ArgumentException("Invalid wine specified for create.");
            }

            if (wine.Id > 0)
            {
                throw new InvalidOperationException("Create not allowed on an already existing wine.");
            }

            using (var session = Db.CreateSession())
            {
                WineBusiness wineBusiness = session.Load<WineBusiness>(wine.BusinessOwner.Id);
                if (wineBusiness == null)
                {
                    wineBusiness = new WineBusiness()
                    {
                        Id = wine.BusinessOwner.Id
                    };
                    session.Store(wineBusiness);
                    session.SaveChanges();
                }

                wine.CreateDate = DateTime.Today;
                wine.BusinessOwner = null; //this not stored in DB
                wine.AddParentBusiness(wineBusiness.Id);

                session.Store(wine);
                session.SaveChanges();

                wineBusiness.AddWine(wine.Id);
                session.Store(wineBusiness);
                session.SaveChanges();
            }

            return this.Json(wine);
        }
    }
}