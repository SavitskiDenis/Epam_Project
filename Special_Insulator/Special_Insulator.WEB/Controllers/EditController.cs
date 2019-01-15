using Common.Entity;
using Specila_Insultor.BLL;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class EditController : Controller
    {

        private IDetaineeBusiness data;
        private IDetentionBusiness detentionData;
        private IAdvertisingBusiness advertising;

        public EditController(IDetaineeBusiness data, IDetentionBusiness detentionData, IAdvertisingBusiness advertising)
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