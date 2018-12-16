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
    public class DetaineesPageController : Controller
    {
        private IDetaineeBusiness data;
        private IDetentionBusiness detention;

        public DetaineesPageController(IDetaineeBusiness data, IDetentionBusiness detention)
        {
            this.data = data;
            this.detention = detention;
        }

        public ActionResult Index()
        {
            return View(data.GetAllDetainees());
        }

        public ActionResult FullInformation(int Id)
        {
            
            return View(data.GetDeteineeById(Id));
        }
    }
}