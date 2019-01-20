using System.Web.Mvc;
using SpecialInsulator.Common.Loger;

namespace Special_Insulator.WEB.Controllers
{
    public class ErrorController : Controller
    {
        private ILogger logger;

        public ErrorController(ILogger logger)
        {
            this.logger = logger;
        }

        public ActionResult AuthorizeError()
        {
            logger.Error("Недопустимые права");
            return View();
        }

        public ActionResult InformationError(string message)
        {
            logger.Error(message);
            ViewBag.Message = message;
            return View();
        }

        public ActionResult NotFoundError()
        {
            return View();
        }
    }
}