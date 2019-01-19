
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
        private IWorkerService data;
        private IDetentionPlaceService department;
        private IDetentionService detentionData;
        private IDetaineeService detaineeData;

        public DetentionsController(IWorkerService data, IDetentionPlaceService department, IDetentionService detentionData, IDetaineeService detaineeData)
        {
            this.data = data;
            this.department = department;
            this.detentionData = detentionData;
            this.detaineeData = detaineeData;
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetention(int? Id)
        {
            if(detaineeData.ExistId(Id))
            {
                List<WorkerAndName> workerAndNames = data.GetAllWorkers();
                List<DetentionPlace> departments = department.GetAllDetentionPlaces();
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
                if(detentionData.AddDetention(detention))
                {
                    return RedirectToAction("FullInformation", "Edit", new { detentionMod.Id });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при добавлении данных!" });

            }
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<DetentionPlace> departments = department.GetAllDetentionPlaces();
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
            if(detentionData.DeleteDetention(Id))
            {
                return RedirectToAction("Index", "Edit");
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка удаления. Проверьте вводимые данные!" });

        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetention(int? Id)
        {
            Detention mydetention = detentionData.GetDetentionById(Id);
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            
            if(mydetention != null && workerAndNames!= null)
            {
                DetentionModel detention = new DetentionModel();
                detention = Mapper.UpdateInfo(detention, mydetention);
                List<DetentionPlace> departments = department.GetAllDetentionPlacesAndSwap(detention.DetentionPlaceId);
                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                //ViewBag.DetainWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames,mydetention.DetainWorker.Worker.Id)), "Id", "LF");
                //ViewBag.DeliveryWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames, mydetention.DeliveryWorker.Worker.Id)), "Id", "LF");
                //ViewBag.ReleaseWorkers = new SelectList(Mapper.MapCollection<WorkerWithNameModel>(data.SwapItems(workerAndNames, mydetention.ReleaseWorker.Worker.Id)), "Id", "LF");
                ViewBag.DetainWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.DetainWorker.Worker.Id),
                                                        "Id",
                                                        "LF");
                ViewBag.DeliveryWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.DeliveryWorker.Worker.Id),
                                                        "Id",
                                                        "LF");
                ViewBag.ReleaseWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, mydetention.ReleaseWorker.Worker.Id),
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
                if(detentionData.EditDetention(detention))
                {
                    return RedirectToAction("FullInformation", "Edit", new { Id = detentionMod.DetaineeId });
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });
            }


            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<DetentionPlace> departments = department.GetAllDetentionPlacesAndSwap(detentionMod.DetentionPlaceId);
            if(workerAndNames != null && departments != null)
            {
                var workers = Mapper.MapCollection<WorkerWithNameModel>(workerAndNames);
                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                ViewBag.DetainWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.DetainWorkerId),
                                                            "Id",
                                                            "LF");
                ViewBag.DeliveryWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.DeliveryWorkerId),
                                                        "Id",
                                                        "LF");
                ViewBag.ReleaseWorkers = new SelectList(data.SwapItems<WorkerWithNameModel>(workerAndNames, detentionMod.ReleaseWorkerId),
                                                        "Id",
                                                        "LF");

                return View(detentionMod);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных." });

        }


    }
}