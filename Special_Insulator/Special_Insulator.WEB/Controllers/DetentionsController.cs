
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
        IWorkerService data;
        IDepartmentService department;
        IDetentionService detentionData;

        public DetentionsController(IWorkerService data, IDepartmentService department, IDetentionService detentionData)
        {
            this.data = data;
            this.department = department;
            this.detentionData = detentionData;
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetention(int Id)
        {
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartments();
            if (workerAndNames.Count == 0 && departments.Count == 0)
            {
                return RedirectToAction("Index", "Edit", new { error = "Необходимо добавить отделы и сотрудников!" });
            }
            else if(workerAndNames.Count == 0)
            {
                return RedirectToAction("Index","Edit",new { error = "Необходимо добавить сотрудников!" });
            }
            else if(departments.Count == 0)
            {
                return RedirectToAction("Index", "Edit", new { error = "Необходимо добавить отделы!" });
            }
            else
            {
                var workers = Mapper.MapCollection<WorkerWithName>(workerAndNames);
                ViewBag.Departments = new SelectList(departments, "Id", "Address");
                ViewBag.Workers = new SelectList(workers, "Id", "LF");
                return View(new DetentionMod { DetaineeId = Id });
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDetention(DetentionMod detentionMod)
        {
            if(ModelState.IsValid)
            {
                Detention detention = Mapper.MapToItem<DetentionMod,Detention>(detentionMod);
                detention.DetainWorker = new WorkerAndName (new Worker { Id = detentionMod .DetainWorkerId}, new Person());
                detention.DeliveryWorker = new WorkerAndName(new Worker { Id = detentionMod.DeliveryWorkerId }, new Person());
                detention.ReleaseWorker = new WorkerAndName(new Worker { Id = detentionMod.ReleaseWorkerId }, new Person());
                detentionData.AddDetention(detention);

                return RedirectToAction("FullInformation", "Edit", new { detentionMod.Id});
            }
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartments();
            var workers = Mapper.MapCollection<WorkerWithName>(workerAndNames);
            ViewBag.Departments = new SelectList(departments, "Id", "Address");
            ViewBag.Workers = new SelectList(workers, "Id", "LF");
            return View(detentionMod);
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDetention(int Id)
        {
            detentionData.DeleteDetention(Id);
            return RedirectToAction("Index", "Edit");
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetention(int Id)
        {
            Detention mydetention = detentionData.GetDetentionById(Id);
            DetentionMod detention = new DetentionMod();
            detention = Mapper.UpdateInfo(detention, mydetention);
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartmentsAndSwap(detention.DepartmentId);

            ViewBag.Departments = new SelectList(departments, "Id", "Address");
            ViewBag.DetainWorkers = new SelectList(Mapper.MapCollection<WorkerWithName>(data.SwapItems(workerAndNames,mydetention.DetainWorker.Worker.Id)), "Id", "LF");
            ViewBag.DeliveryWorkers = new SelectList(Mapper.MapCollection<WorkerWithName>(data.SwapItems(workerAndNames, mydetention.DeliveryWorker.Worker.Id)), "Id", "LF");
            ViewBag.ReleaseWorkers = new SelectList(Mapper.MapCollection<WorkerWithName>(data.SwapItems(workerAndNames, mydetention.ReleaseWorker.Worker.Id)), "Id", "LF");
            return View(detention);
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDetention(DetentionMod detentionMod)
        {
            if (ModelState.IsValid)
            {
                Detention detention = Mapper.MapToItem<DetentionMod, Detention>(detentionMod);
                detention.DetainWorker = new WorkerAndName(new Worker { Id = detentionMod.DetainWorkerId }, new Person());
                detention.DeliveryWorker = new WorkerAndName(new Worker { Id = detentionMod.DeliveryWorkerId }, new Person());
                detention.ReleaseWorker = new WorkerAndName(new Worker { Id = detentionMod.ReleaseWorkerId }, new Person());
                detentionData.EditDetention(detention);

                return RedirectToAction("FullInformation", "Edit", new { Id = detentionMod.DetaineeId });
            }


            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartments();
            var workers = Mapper.MapCollection<WorkerWithName>(workerAndNames);
            ViewBag.Departments = new SelectList(departments, "Id", "Address");
            ViewBag.DetainWorkers = new SelectList(workers, "Id", "LF");
            ViewBag.DeliveryWorkers = new SelectList(workers, "Id", "LF");
            ViewBag.ReleaseWorkers = new SelectList(workers, "Id", "LF");

            return View(detentionMod);
        }


    }
}