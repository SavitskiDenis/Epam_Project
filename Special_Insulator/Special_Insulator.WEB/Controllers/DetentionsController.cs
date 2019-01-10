
using Common.Entity;
using Common.Mapper;
using Special_Insulator.WEB.Models;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class DetentionsController : Controller
    {
        IWorkerBusiness data;
        IDepartmentBusiness department;
        IDetentionBusiness detentionData;

        public DetentionsController(IWorkerBusiness data, IDepartmentBusiness department, IDetentionBusiness detentionData)
        {
            this.data = data;
            this.department = department;
            this.detentionData = detentionData;
        }

        [HttpGet]
        public ActionResult AddDetention(int Id)
        {
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartments();
            var workers = Mapper.MapCollection<WorkerWithName>(workerAndNames);
            ViewBag.Departments = new SelectList(departments,"Id", "Address");
            ViewBag.Workers = new SelectList(workers,"Id", "LF");
            return View(new DetentionMod { DetaineeId = Id});
        }

        [HttpPost]
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

        public ActionResult DeleteDetention(int Id)
        {
            detentionData.DeleteDetention(Id);
            return RedirectToAction("Index", "Edit");
        }

        [HttpGet]
        public ActionResult EditDetention(int Id)
        {
            List<WorkerAndName> workerAndNames = data.GetAllWorkers();
            List<Department> departments = department.GetAllDepartments();
            Detention mydetention = detentionData.GetDetentionById(Id);
            DetentionMod detention = new DetentionMod();
            detention = Mapper.UpdateInfo<Detention, DetentionMod>(detention, mydetention);
            var workers = Mapper.MapCollection<WorkerWithName>(workerAndNames);

            ViewBag.Departments = new SelectList(departments, "Id", "Address");
            ViewBag.DetainWorkers = new SelectList(workers, "Id", "LF");
            ViewBag.DeliveryWorkers = new SelectList(workers, "Id", "LF");
            ViewBag.ReleaseWorkers = new SelectList(workers, "Id", "LF");
            return View(detention);
        }

        [HttpPost]
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