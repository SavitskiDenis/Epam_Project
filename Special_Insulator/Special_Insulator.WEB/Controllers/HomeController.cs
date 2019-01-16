using SpecialInsulator.BLL.Interfaces;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class HomeController : Controller
    {
        IAdvertisingService advertising;

        public HomeController(IAdvertisingService advertising)
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