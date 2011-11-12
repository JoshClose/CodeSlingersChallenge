﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSlingers.Web.Services;

namespace CodeSlingers.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IFourSquareApi _fourSquareApi;

        public LocationController(IFourSquareApi fourSquareApi)
        {
            _fourSquareApi = fourSquareApi;
        }

        [HttpGet]
        public ActionResult NearbyBusinesses(decimal latitude, decimal longitude)
        {
            var allBusinesses = _fourSquareApi.GetNearbyVenues(latitude, longitude);
            return this.Json(allBusinesses, JsonRequestBehavior.AllowGet);
        }

    }
}