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
    public class EditInformationController : Controller
    {
        IDetaineeBusiness detainee;

        public EditInformationController(IDetaineeBusiness detainee)
        {
            this.detainee = detainee;
        }

        [HttpGet]
        public ActionResult EditDetaineeInfo(int Id)
        {
            DetaineeWithName myDetainee =  detainee.GetDeteineeById(Id);

            EditDitanee editDitanee = new EditDitanee()
            {
                Id = myDetainee.detainee.Id,
                Status = myDetainee.detainee.Status,
                Workplace = myDetainee.detainee.Workplace,
                Address = myDetainee.detainee.Address,
                Additional_information = myDetainee.detainee.Additional_information
            };

            return View(editDitanee);
        }

        [HttpPost]
        public ActionResult EditDetaineeInfo(EditDitanee editDitanee)
        {
            if (ModelState.IsValid)
            {
                DetaineeWithName myDetainee = detainee.GetDeteineeById(editDitanee.Id);
                myDetainee.detainee.Status = editDitanee.Status;
                myDetainee.detainee.Workplace = editDitanee.Workplace;
                myDetainee.detainee.Address = editDitanee.Address;
                myDetainee.detainee.Additional_information = editDitanee.Additional_information;
                detainee.UpdateDetaineeInfo(myDetainee.detainee);

                return RedirectToAction("FullInformation","Edit",new { myDetainee.detainee.Id});
            }
            return View(editDitanee);
        }


    }
}