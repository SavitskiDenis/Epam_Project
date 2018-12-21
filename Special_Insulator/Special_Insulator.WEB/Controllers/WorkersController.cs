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
    public class WorkersController : Controller
    {
        IWorkerBusiness data;

        public WorkersController(IWorkerBusiness data)
        {
            this.data = data;
        }

        [HttpGet]
        public ActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWorker(WorkerWithName worker)
        {
            if (ModelState.IsValid)
            {
                var addWorker = Mapper.MapToItem<WorkerWithName, Worker>(worker);
                var addPerson = Mapper.MapToItem<WorkerWithName, Person>(worker);

                data.AddWorker(addWorker,addPerson);

                return RedirectToAction("Index", "Edit");
            }

            return View(worker);
        }


    }
}