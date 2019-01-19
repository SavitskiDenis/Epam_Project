using SpecialInsulator.BLL.Interfaces;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IAdvertisingService advertising;

        public HomeController(IAdvertisingService advertising)
        {
            this.advertising = advertising;
        }

        public ActionResult Index()
        {
            var collection = advertising.GetLinks();
            if(collection != null)
            {
                ViewBag.Advertising = collection;
                return View();
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

    }
}