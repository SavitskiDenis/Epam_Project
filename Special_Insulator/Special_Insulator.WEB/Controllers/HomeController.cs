using SpecialInsulator.BLL.Interfaces;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IAdvertisingService advertisingService;

        public HomeController(IAdvertisingService advertising)
        {
            this.advertisingService = advertising;
        }

        public ActionResult Index()
        {
            var collection = advertisingService.GetLinks();
            if(collection != null)
            {
                ViewBag.Advertising = collection;
                return View();
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        public ActionResult Others()
        {
            var collection = advertisingService.GetLinks();
            if (collection != null)
            {
                ViewBag.Advertising = collection;
                return View();
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }
       
    }
}