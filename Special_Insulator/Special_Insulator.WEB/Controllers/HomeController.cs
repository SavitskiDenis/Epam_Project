using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class HomeController : Controller
    {
        IAdvertisingBusiness advertising;

        public HomeController(IAdvertisingBusiness advertising)
        {
            this.advertising = advertising;

        }

        public ActionResult Index()
        {
            var collection = advertising.GetLinks();
            ViewBag.Advertising = collection;
            return View();
        }

    }
}