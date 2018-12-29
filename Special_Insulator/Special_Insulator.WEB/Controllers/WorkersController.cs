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

        public ActionResult Index()
        {
            return View(data.GetAllWorkers());
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

        public ActionResult DeleteWorker(int Id)
        {
            data.DeleteWorkerById(Id);
            return RedirectToAction("Index","Workers");
        }

        [HttpGet]
        public ActionResult EditWorker(int Id)
        {
            WorkerAndName myWorker = data.GetWorkerById(Id);
            WorkerWithName editWorker = Mapper.MapToItem<Person, WorkerWithName>(myWorker.Person);
            editWorker = Mapper.UpdateInfo<Worker, WorkerWithName>(editWorker, myWorker.Worker);

            return View(editWorker);
        }

        [HttpPost]
        public ActionResult EditWorker(WorkerWithName editWorker)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.MapToItem<WorkerWithName, Person>(editWorker);
                var worker = Mapper.MapToItem<WorkerWithName, Worker>(editWorker);
                data.EditWorker(new WorkerAndName(worker, person));
                return RedirectToAction("Index", "Workers");
            }

            return View(editWorker);
        }
    }
}