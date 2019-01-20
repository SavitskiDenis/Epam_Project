using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.Common.Entity;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class EditController : Controller
    {

        private IDetaineeService detaineeService;
        private IDetentionService detentionService;
        private IAdvertisingService advertisingService;

        public EditController(IDetaineeService data, IDetentionService detentionData, IAdvertisingService advertising)
        {
            this.detaineeService = data;
            this.detentionService = detentionData;
            this.advertisingService = advertising;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index(string error = "")
        {
            var collection = advertisingService.GetLinks();
            var detainees = detaineeService.GetAllDetainees();
            if(detainees != null && collection!= null)
            {
                ViewBag.Advertising = collection;
                ViewBag.Error = error;
                return View(detainees);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [Authorize(Roles = "Editor")]
        public ActionResult FullInformation(int? Id )
        {
            DetaineeWithName mydetainee = detaineeService.GetDeteineeById(Id);
            if(mydetainee!= null)
            {
                mydetainee.detainee.Detentions = detentionService.GetDetentionsByDetaineeId(Id);
                ViewBag.DetaineeId = Id;
                return View(mydetainee);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        
    }
}