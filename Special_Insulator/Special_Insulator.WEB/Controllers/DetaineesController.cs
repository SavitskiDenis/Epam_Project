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

        public ActionResult DeleteDetainee(int Id)
        {
            data.DeleteDetaineeById(Id);
            return RedirectToAction("Index", "Edit");
        }

        [HttpPost]
        public ActionResult FindDetainee(string search,string type = "All")
        {
            IEnumerable<DetaineeWithName> collection ;
            if (type == "Все")
            {
                collection = data.GetAllDetainees();
            }
            else if(type == "По ФИ")
            {
                collection = data.GetAllDetainees().FindAll(item => (item.person.LastName +" "+ item.person.FirstName) == search);
            }
            else if(type == "По адресу")
            {
                collection = data.GetAllDetainees().FindAll(item => item.detainee.Address == search);
            }
            else
            {
                collection = null;
            }
            
            return PartialView(collection);
        }

        public ActionResult FullInformation(int Id)
        {
            DetaineeWithName mydetainee =  data.GetDeteineeById(Id);
            mydetainee.detainee.Detentions = detention.GetDetentionsByDetaineeId(Id);
            return View(mydetainee);
        }

        [HttpGet]
        public ActionResult AddDetainee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDetainee(DetaineeWithNameMod detainee)
        {
            if (ModelState.IsValid)
            {
                var addDetainee = Mapper.MapToItem<DetaineeWithNameMod, Detainee>(detainee);
                var addPerson = Mapper.MapToItem<DetaineeWithNameMod, Person>(detainee);

                data.AddDetainee(addPerson, addDetainee);

                return RedirectToAction("Index", "Edit");
            }

            return View(detainee);
        }

        [HttpGet]
        public ActionResult EditDetaineeInfo(int Id)
        {
            DetaineeWithName myDetainee = data.GetDeteineeById(Id);
            DetaineeWithNameMod editDetainee = Mapper.MapToItem<Person, DetaineeWithNameMod>(myDetainee.person);
            editDetainee = Mapper.UpdateInfo(editDetainee, myDetainee.detainee);
            return View(editDetainee);
        }

        [HttpPost]
        public ActionResult EditDetaineeInfo(DetaineeWithNameMod editDitanee)
        {
            if (ModelState.IsValid)
            { 
                var person = Mapper.MapToItem<DetaineeWithNameMod, Person>(editDitanee);
                var detainee = Mapper.MapToItem<DetaineeWithNameMod, Detainee>(editDitanee);
                data.EditDetaineeInfo(new DetaineeWithName(detainee,person));
                return RedirectToAction("FullInformation", "Edit", new { editDitanee.Id});
            }
            return View(editDitanee);
        }

    }
}