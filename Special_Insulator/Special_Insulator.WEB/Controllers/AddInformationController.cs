using Common.Entity;
using Special_Insulator.WEB.Models;
using Specila_Insultor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{

    public class AddInformationController : Controller
    {
        IDetaineeBusiness data;

        public AddInformationController(IDetaineeBusiness data)
        {
            this.data = data;
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
                Detainee addDetainee = new Detainee();
                Person addPerson = new Person();

                var date = detainee.BornDate.Split('.');
                addDetainee.BornDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                addPerson.FirstName = detainee.FirstName;
                addPerson.LastName = detainee.LastName;

                addDetainee.Address = detainee.Address;
                addDetainee.Additional_information = detainee.Additional_information;
                addDetainee.Phone = detainee.Phone;
                addDetainee.Photo = detainee.Photo;
                
                
                addDetainee.Status = detainee.Status;
                addDetainee.Workplace = detainee.Workplace;

                data.AddDetainee(addPerson,addDetainee);
                return RedirectToAction("Index","Edit");
            }
             
            return View(detainee);
        }
    }
}