using Common.Entity;
using Common.Mapper;
using Special_Insulator.WEB.Models;
using Specila_Insultor.BLL;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Special_Insulator.WEB.Controllers
{
    public class DetaineesController : Controller
    {
        private IDetaineeBusiness data;
        private IDetentionBusiness detention;

        public DetaineesController(IDetaineeBusiness data, IDetentionBusiness detention)
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

        [HttpGet]
        public ActionResult AddDetainee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDetainee(CreateDetaineeWithName detainee)
        {
            if (ModelState.IsValid)
            {
                var addDetainee = Mapper.MapToItem<CreateDetaineeWithName, Detainee>(detainee);
                var addPerson = Mapper.MapToItem<CreateDetaineeWithName, Person>(detainee);

                data.AddDetainee(addPerson, addDetainee);

                return RedirectToAction("Index", "Edit");
            }

            return View(detainee);
        }

        [HttpGet]
        public ActionResult EditDetaineeInfo(int Id)
        {
            DetaineeWithName myDetainee = data.GetDeteineeById(Id);
            var editDitanee = Mapper.MapToItem<Detainee, EditDitanee>(myDetainee.detainee);
            //EditDitanee editDitanee = new EditDitanee()
            //{
            //    Id = myDetainee.detainee.Id,
            //    Status = myDetainee.detainee.Status,
            //    Workplace = myDetainee.detainee.Workplace,
            //    Address = myDetainee.detainee.Address,
            //    AdditionalInformation = myDetainee.detainee.AdditionalInformation
            //};

            return View(editDitanee);
        }

        [HttpPost]
        public ActionResult EditDetaineeInfo(EditDitanee editDitanee)
        {
            if (ModelState.IsValid)
            {
                DetaineeWithName myDetainee = data.GetDeteineeById(editDitanee.Id);
                myDetainee.detainee.Status = editDitanee.Status;
                myDetainee.detainee.Workplace = editDitanee.Workplace;
                myDetainee.detainee.Address = editDitanee.Address;
                myDetainee.detainee.AdditionalInformation = editDitanee.AdditionalInformation;

                //var editDitanee = Mapper.MapToItem<EditDitanee, Detainee>(myDetainee);
                data.UpdateDetaineeInfo(myDetainee.detainee);

                return RedirectToAction("FullInformation", "Edit", new { myDetainee.detainee.Id });
            }
            return View(editDitanee);
        }

    }
}