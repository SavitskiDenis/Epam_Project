using Common.Entity;
using Common.Mapper;
using Special_Insulator.WEB.Models;
using Specila_Insultor.BLL;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Special_Insulator.WEB.Controllers
{
    public class DetaineesController : Controller
    {
        private IDetaineeBusiness data;
        private IDetentionBusiness detention;
        private IAdvertisingBusiness advertising;

        public DetaineesController(IDetaineeBusiness data, IDetentionBusiness detention, IAdvertisingBusiness advertising)
        {
            this.data = data;
            this.detention = detention;
            this.advertising = advertising;
        }

        public ActionResult Index()
        {
            var collection = advertising.GetLinks();
            ViewBag.Advertising = collection;
            return View(data.GetAllDetainees());
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDetainee(int Id)
        {
            data.DeleteDetaineeById(Id);
            return RedirectToAction("Index", "Edit");
        }

        [HttpPost]
        public ActionResult FindDetainee(string search,string type = "Все",string sort="По возрастанию")
        {
            IEnumerable<DetaineeWithName> collection;
            if (type == "Все")
            {
                collection = data.GetAllDetainees();
            }
            else if(type == "По ФИО")
            {
                collection = data.GetAllDetainees().FindAll(item => (item.person.LastName +" "+ item.person.FirstName+" "+item.person.Patronymic).Contains(search));
            }
            else if(type == "По адресу")
            {
                collection = data.GetAllDetainees().FindAll(item => item.detainee.Address == search);
            }
            else
            {
                collection = data.GetAllDetainees().FindAll(item => item.lastDetention.ToShortDateString() == search);
            }

            //if (sort == "По возрастанию")
            //{
            //    collection?.ToList().Sort();
            //}
            //else
            //{
            //    collection?.ToList().Sort();
            //    collection?.Reverse();
            //}

            return PartialView(collection);
        }

        public ActionResult FullInformation(int Id)
        {
            DetaineeWithName mydetainee =  data.GetDeteineeById(Id);
            mydetainee.detainee.Detentions = detention.GetDetentionsByDetaineeId(Id);
            return View(mydetainee);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetainee()
        {
            return View(new DetaineeWithNameMod());
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetainee(DetaineeWithNameMod detainee, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage!=null)
            {
                var addDetainee = Mapper.MapToItem<DetaineeWithNameMod, Detainee>(detainee);
                var addPerson = Mapper.MapToItem<DetaineeWithNameMod, Person>(detainee);
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    addDetainee.Photo = binaryReader.ReadBytes(uploadImage.ContentLength);
                }
                
                data.AddDetainee(addPerson, addDetainee);

                return RedirectToAction("Index", "Edit");
            }

            return View(detainee);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetaineeInfo(int Id)
        {
            DetaineeWithName myDetainee = data.GetDeteineeById(Id);
            DetaineeWithNameMod editDetainee = Mapper.MapToItem<Person, DetaineeWithNameMod>(myDetainee.person);
            editDetainee = Mapper.UpdateInfo(editDetainee, myDetainee.detainee);
            return View(editDetainee);
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetaineeInfo(DetaineeWithNameMod editDitanee, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            { 
                var person = Mapper.MapToItem<DetaineeWithNameMod, Person>(editDitanee);
                var detainee = Mapper.MapToItem<DetaineeWithNameMod, Detainee>(editDitanee);
                if (uploadImage != null)
                {
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        detainee.Photo = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                }
                data.EditDetaineeInfo(new DetaineeWithName(detainee,person));
                
                return RedirectToAction("FullInformation", "Edit", new { editDitanee.Id});
            }
            return View(editDitanee);
        }

    }
}