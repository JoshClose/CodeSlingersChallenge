using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutofacExample.Services;

namespace AutofacExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        private readonly ISecondService _secondService;

        public HomeController(ITestService testService, ISecondService secondService)
        {
            _testService = testService;
            _secondService = secondService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _testService.DoStuff();
            ViewBag.Message2 = _secondService.DoSecondThing();
            return View();
        }

    }
}
