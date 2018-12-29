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

        public EditController(IDetaineeBusiness data, IDetentionBusiness detentionData)
        {
            this.data = data;
            this.detentionData = detentionData;
        }

        public ActionResult Index()
        {
            return View(data.GetAllDetainees());
        }

        public ActionResult DeleteDetainee(int id )
        {
            data.DeleteDetaineeById(id);
            return RedirectToAction("Index","Edit");
        }

        public ActionResult FullInformation(int Id )
        {
            DetaineeWithName mydetainee = data.GetDeteineeById(Id);
            mydetainee.detainee.Detentions = detentionData.GetDetentionsByDetaineeId(Id);
            return View(mydetainee);
        }

        
    }
}