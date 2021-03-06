﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeSlingers.Web.Services;

namespace CodeSlingers.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDummyService _dummyService;

        public HomeController(IDummyService dummyService)
        {
            _dummyService = dummyService;
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
