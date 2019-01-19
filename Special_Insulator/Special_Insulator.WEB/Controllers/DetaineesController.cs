using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class DetaineesController : Controller
    {
        private readonly IDetaineeService data;
        private readonly IDetentionService detention;
        private readonly IAdvertisingService advertising;
        private readonly IStatusService status;

        public DetaineesController(IDetaineeService data, IDetentionService detention, IAdvertisingService advertising, IStatusService status)
        {
            this.data = data;
            this.detention = detention;
            this.advertising = advertising;
            this.status = status;
        }

        public ActionResult Index()
        {
            var collection = advertising.GetLinks();
            if(collection != null)
            {
                ViewBag.Advertising = collection;
                return View(data.GetAllDetainees());
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDetainee(int? Id)
        {
            if(data.DeleteDetaineeById(Id))
            {
                return RedirectToAction("Index", "Edit");
            }
            return RedirectToAction("InformationError", "Error",new { message ="Ошибка удаления. Проверьте вводимые данные!"});
        }

        [HttpPost]
        public ActionResult FindDetainee(string search,string type = "Все")
        {
            var collection = data.SortCollectionByType(search, type);
            if (collection != null)
            {
                return PartialView(collection);
            }
            return RedirectToAction("InformationError", "Error",new { message ="Ошибка получения списка!"});


        }

        public ActionResult FullInformation(int? Id)
        {
            DetaineeWithName mydetainee =  data.GetDeteineeById(Id);
            if(mydetainee != null)
            {
                mydetainee.detainee.Detentions = detention.GetDetentionsByDetaineeId(int.Parse(Id.ToString()));
                return View(mydetainee);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произолша ошибка при получении информации задержанного. Возможно введены не верные данные" });

        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetainee()
        {
            var statuses = status.GetAllStatuses();
            if(statuses != null && statuses.Count > 0)
            {
                ViewBag.Statuses = new SelectList(statuses, "Id", "StatusName");
                return View(new DetaineeWithNameModel());
            }
            else if(statuses != null && statuses.Count == 0)
            {
                return RedirectToAction("Index", "Edit", new { error = "Невозможно добавить задержанного. Необходимо добавить список семейного положения" });
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка получения данных!" });

        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetainee(DetaineeWithNameModel detainee, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage!=null)
            {
                var addDetainee = Mapper.MapToItem<DetaineeWithNameModel, Detainee>(detainee);
                var addPerson = Mapper.MapToItem<DetaineeWithNameModel, Person>(detainee);

                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    addDetainee.Photo = binaryReader.ReadBytes(uploadImage.ContentLength);
                }

                addDetainee.Status = new Status { Id = detainee.StatusId};

                if(data.AddDetainee(addPerson, addDetainee))
                {
                    return RedirectToAction("Index", "Edit");
                }
                else
                {
                    return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при добавлении задержанного" });
                }
            }
            else if(uploadImage == null)
            {
                ViewBag.Error = "Не выбрано фото";
            }

            var statuses = status.GetAllStatuses();
            if (statuses != null && statuses.Count > 0)
            {
                ViewBag.Statuses = new SelectList(statuses, "Id", "StatusName");
                return View(detainee);
            }
            else if (statuses != null && statuses.Count == 0)
            {
                return RedirectToAction("Index", "Edit", new { error = "Невозможно добавить задержанного. Необходимо добавить список семейного положения" });
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка получения данных!" });

        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetaineeInfo(int? Id)
        {
            DetaineeWithName myDetainee = data.GetDeteineeById(Id);
            if(myDetainee != null)
            {
                DetaineeWithNameModel editDetainee = Mapper.MapToItem<Person, DetaineeWithNameModel>(myDetainee.person);
                editDetainee = Mapper.UpdateInfo(editDetainee, myDetainee.detainee);
                editDetainee.StatusId = myDetainee.detainee.Status.Id;

                var statuses = status.GetAllStatusesAndSwap(editDetainee.StatusId);

                if (statuses != null && statuses.Count > 0)
                {
                    ViewBag.Statuses = new SelectList(statuses, "Id", "StatusName");
                    return View(editDetainee);
                }
                else if(statuses != null && statuses.Count == 0)
                {
                    return RedirectToAction("Index", "Edit", new { error = "Невозможно добавить задержанного. Необходимо добавить список семейного положения" });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Ошибка получения данных!" });
            }
            else
            {
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении инфорации о  задержанном" });
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetaineeInfo(DetaineeWithNameModel editDitainee, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            { 
                var person = Mapper.MapToItem<DetaineeWithNameModel, Person>(editDitainee);
                var detainee = Mapper.MapToItem<DetaineeWithNameModel, Detainee>(editDitainee);
                if (uploadImage != null)
                {
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        detainee.Photo = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                }
                detainee.Status = new Status { Id = editDitainee.StatusId };

                if(data.EditDetaineeInfo(new DetaineeWithName(detainee, person)))
                {
                    return RedirectToAction("FullInformation", "Edit", new { editDitainee.Id });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении инфорации о  задержанном" });


            }

            var statuses = status.GetAllStatusesAndSwap(editDitainee.StatusId);

            if (statuses != null && statuses.Count > 0)
            {
                ViewBag.Statuses = new SelectList(statuses, "Id", "StatusName");
                return View(editDitainee);
            }
            else if (statuses != null && statuses.Count == 0)
            {
                return RedirectToAction("Index", "Edit", new { error = "Невозможно добавить задержанного. Необходимо добавить список семейного положения" });
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка получения данных!" });

        }

    }
}