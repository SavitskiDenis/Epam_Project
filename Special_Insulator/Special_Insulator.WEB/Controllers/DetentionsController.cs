
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
            ViewBag.Workers = new SelectList(workers,"Id","FirstName", "LastName");
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

            return View(detentionMod);
        }

        
    }
}