using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class EditController : Controller
    {

        private IDetaineeService data;
        private IDetentionService detentionData;
        private IAdvertisingService advertising;

        public EditController(IDetaineeService data, IDetentionService detentionData, IAdvertisingService advertising)
        {
            this.data = data;
            this.detentionData = detentionData;
            this.advertising = advertising;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index(string error = "")
        {
            var collection = advertising.GetLinks();
            ViewBag.Advertising = collection;
            ViewBag.Error = error;
            return View(data.GetAllDetainees());
        }

        [Authorize(Roles = "Editor")]
        public ActionResult FullInformation(int Id )
        {
            DetaineeWithName mydetainee = data.GetDeteineeById(Id);
            mydetainee.detainee.Detentions = detentionData.GetDetentionsByDetaineeId(Id);
            ViewBag.DetaineeId = Id;
            return View(mydetainee);
        }

        
    }
}