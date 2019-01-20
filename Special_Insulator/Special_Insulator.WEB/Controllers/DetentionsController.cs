
using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class DetentionsController : Controller
    {
        private IWorkerService workerService;
        private IDetentionPlaceService placeService;
        private IDetentionService detentionService;
        private IDetaineeService detaineeService;

        public DetentionsController(IWorkerService data, IDetentionPlaceService department, IDetentionService detentionData, IDetaineeService detaineeData)
        {
            this.workerService = data;
            this.placeService = department;
            this.detentionService = detentionData;
            this.detaineeService = detaineeData;
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetention(int? Id)
        {
            if(detaineeService.ExistId(Id))
            {
                List<WorkerAndName> workerAndNames = workerService.GetAllWorkers();
                List<DetentionPlace> departments = placeService.GetAllDetentionPlaces();
                if (workerAndNames.Count == 0 && departments.Count == 0)
                {
                    return RedirectToAction("Index", "Edit", new { error = "Необходимо добавить отделы и сотрудников!" });
                }
                else if (workerAndNames.Count == 0)
                {
                    return RedirectToAction("Index", "Edit", new { error = "Необходимо добавить сотрудников!" });
                }
                else if (departments.Count == 0)
                {
                    return RedirectToAction("Index", "Edit", new { error = "Необходимо добавить отделы!" });
                }
                else
                {
                    var workers = Mapper.MapCollection<WorkerWithNameModel>(workerAndNames);
                    ViewBag.Departments = new SelectList(departments, "Id", "Address");
                    ViewBag.Workers = new SelectList(workers, "Id", "LF");
                    return View(new DetentionModel { DetaineeId = int.Parse(Id.ToString()) });
                }
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка добавления. Проверьте вводимые данные!" });

        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetention(DetentionModel detentionMod)
        {
            if(ModelState.IsValid)
            {
                Detention detention = Mapper.MapToItem<DetentionModel,Detention>(detentionMod);
                detention.DetentionPlace = new DetentionPlace { Id = detentionMod.DetentionPlaceId};
                detention.DetainWorker = new WorkerAndName (new Worker { Id = detentionMod .DetainWorkerId}, new Person());
                detention.DeliveryWorker = new WorkerAndName(new Worker { Id = detentionMod.DeliveryWorkerId }, new Person());
                detention.ReleaseWorker = new WorkerAndName(new Worker { Id = detentionMod.ReleaseWorkerId }, new Person());
                if(detentionService.AddDetention(detention))
                {
                    return RedirectToAction("FullInformation", "Edit", new { detentionMod.Id });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при добавлении данных!" });

            }
            List<WorkerAndName> workerAndNames = workerService.GetAllWorkers();
            List<DetentionPlace> departments = placeService.GetAllDetentionPlaces();
            if(workerAndNames != null && departments != null)
            {
                var workers = Mapper.MapCollection<WorkerWithNameModel>(workerAndNames);

                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                ViewBag.Workers = new SelectList(workers, "Id", "LF");

                return View(detentionMod);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDetention(int? Id)
        {
            int id = detentionService.DeleteDetention(Id);
            if (id > 0)
            {
                return RedirectToAction("FullInformation", "Edit",new { Id = id});
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка удаления. Проверьте вводимые данные!" });

        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetention(int? Id)
        {
            Detention mydetention = detentionService.GetDetentionById(Id);
            List<WorkerAndName> workerAndNames = workerService.GetAllWorkers();
            
            if(mydetention != null && workerAndNames!= null)
            {
                DetentionModel detention = new DetentionModel();
                detention = Mapper.UpdateInfo(detention, mydetention);
                List<DetentionPlace> departments = placeService.GetAllDetentionPlacesAndSwap(detention.DetentionPlaceId);
                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                //ViewBag.DetainWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames,mydetention.DetainWorker.Worker.Id)), "Id", "LF");
                //ViewBag.DeliveryWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames, mydetention.DeliveryWorker.Worker.Id)), "Id", "LF");
                //ViewBag.ReleaseWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames, mydetention.ReleaseWorker.Worker.Id)), "Id", "LF");
                ViewBag.DetainWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.DetainWorker.Worker.Id),
                                                        "Id",
                                                        "LF");
                ViewBag.DeliveryWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.DeliveryWorker.Worker.Id),
                                                        "Id",
                                                        "LF");
                ViewBag.ReleaseWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.ReleaseWorker.Worker.Id),
                                                        "Id",
                                                        "LF");
                return View(detention);
            }
            else if(mydetention != null && workerAndNames == null)
            {
                return RedirectToAction("Index","Edit",new { error = "Необходимо добавить сотрудников"});
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных. Проверьте вводимые параметры!" });
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetention(DetentionModel detentionMod)
        {
            if (ModelState.IsValid)
            {
                Detention detention = Mapper.MapToItem<DetentionModel, Detention>(detentionMod);
                detention.DetentionPlace = new DetentionPlace { Id = detentionMod.DetentionPlaceId};
                detention.DetainWorker = new WorkerAndName(new Worker { Id = detentionMod.DetainWorkerId }, new Person());
                detention.DeliveryWorker = new WorkerAndName(new Worker { Id = detentionMod.DeliveryWorkerId }, new Person());
                detention.ReleaseWorker = new WorkerAndName(new Worker { Id = detentionMod.ReleaseWorkerId }, new Person());
                if(detentionService.EditDetention(detention))
                {
                    return RedirectToAction("FullInformation", "Edit", new { Id = detentionMod.DetaineeId });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });
            }


            List<WorkerAndName> workerAndNames = workerService.GetAllWorkers();
            List<DetentionPlace> departments = placeService.GetAllDetentionPlacesAndSwap(detentionMod.DetentionPlaceId);
            if(workerAndNames != null && departments != null)
            {
                var workers = Mapper.MapCollection<WorkerWithNameModel>(workerAndNames);
                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                ViewBag.DetainWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.DetainWorkerId),
                                                            "Id",
                                                            "LF");
                ViewBag.DeliveryWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.DeliveryWorkerId),
                                                        "Id",
                                                        "LF");
                ViewBag.ReleaseWorkers = new SelectList(workerService.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.ReleaseWorkerId),
                                                        "Id",
                                                        "LF");

                return View(detentionMod);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных." });

        }


    }
}