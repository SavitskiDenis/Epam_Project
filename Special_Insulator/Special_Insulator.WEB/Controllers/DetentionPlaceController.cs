using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using System.Web.Mvc;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class DetentionPlaceController : Controller
    {
        IDetentionPlaceService data;

        public DetentionPlaceController(IDetentionPlaceService data)
        {
            this.data = data;
        }

        [Authorize(Roles ="Editor")]
        public ActionResult Index()
        {
            var collection = data.GetAllDetentionPlaces();
            if (collection!=null)
            {
                return View(collection);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка получения списка мест содержания!" });
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetentionPlace()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetentionPlace(DetentionPlaceModel department)
        {
            if(ModelState.IsValid)
            {
                if(data.IsNewPlace(department.Address))
                {
                    var addDepartment = Mapper.MapToItem<DetentionPlaceModel, DetentionPlace>(department);

                    if(data.AddDetentionPlace(addDepartment))
                    {
                        return RedirectToAction("Index", "Edit");
                    }

                    return RedirectToAction("InformationError", "Error", new { message = "Ошибка добавления места содержания" });
                }
                ViewBag.Error = "Такое место содержания уже существует";
                
            }

            return View(department);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetentionPlace(int? Id)
        {
            var place = data.GetDetentionPlaceById(Id);
            if (place != null)
            {
                DetentionPlaceModel department = Mapper.MapToItem<DetentionPlace, DetentionPlaceModel>(place);
                return View(department);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных места содержания. Проверьте вводимые данные!" });
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetentionPlace(DetentionPlaceModel department)
        {
            if (ModelState.IsValid)
            {
                if (data.IsNewPlace(department.Address))
                {
                    DetentionPlace dep = Mapper.MapToItem<DetentionPlaceModel, DetentionPlace>(department);
                    if(data.EditDetentionPlace(dep))
                    {
                        return RedirectToAction("Index", "DetentionPlace");
                    }
                    return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });
                }
                ViewBag.Error = "Такое место содержания уже существует";
            }
            return View(department);
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDetentionPlace(int? Id)
        {
            if(data.DeleteDetentionPlaceById(Id))
            {
                return RedirectToAction("Index", "DetentionPlace");
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при удалении данных. Проверьте вводимые данные!" });

        }

    }
}