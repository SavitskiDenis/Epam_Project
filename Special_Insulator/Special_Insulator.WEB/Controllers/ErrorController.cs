using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult AuthorizeError()
        {
            return View();
        }

        public ActionResult InformationError(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}