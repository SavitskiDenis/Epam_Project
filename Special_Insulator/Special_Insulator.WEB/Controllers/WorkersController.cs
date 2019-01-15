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
        IPostBusiness post;

        public WorkersController(IWorkerBusiness data,IPostBusiness post)
        {
            this.data = data;
            this.post = post;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index()
        {
            return View(data.GetAllWorkers());
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddWorker()
        {
            var posts = post.GetAllPosts();
            if(posts.Count>0)
            {
                ViewBag.Posts = new SelectList(posts, "Id", "PostName");
                return View();
            }
            else
            {
                return RedirectToAction("Index","Edit", new { error = "Необходимо добавить должности!" });
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddWorker(WorkerWithName worker)
        {
            if (ModelState.IsValid)
            {
                var addWorker = Mapper.MapToItem<WorkerWithName, Worker>(worker);
                var addPerson = Mapper.MapToItem<WorkerWithName, Person>(worker);
                addWorker.WorkerPost =new Post {Id =  worker.WorkerPostId };

                data.AddWorker(addWorker,addPerson);

                return RedirectToAction("Index", "Edit");
            }
            var posts = post.GetAllPosts();
            ViewBag.Posts = new SelectList(posts, "Id", "PostName");
            return View(worker);
        }

        public ActionResult DeleteWorker(int Id)
        {
            data.DeleteWorkerById(Id);
            return RedirectToAction("Index","Workers");
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditWorker(int Id)
        {
            WorkerAndName myWorker = data.GetWorkerById(Id);
            var posts = post.SwapPost(myWorker.Worker.WorkerPost.Id);
            ViewBag.Posts = new SelectList(posts, "Id", "PostName");
            WorkerWithName editWorker = Mapper.MapToItem<Person, WorkerWithName>(myWorker.Person);
            editWorker = Mapper.UpdateInfo(editWorker, myWorker.Worker);
            editWorker.WorkerPostId = myWorker.Worker.WorkerPost.Id;
            return View(editWorker);
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditWorker(WorkerWithName editWorker)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.MapToItem<WorkerWithName, Person>(editWorker);
                var worker = Mapper.MapToItem<WorkerWithName, Worker>(editWorker);
                worker.WorkerPost = new Post { Id = editWorker.WorkerPostId};
                data.EditWorker(new WorkerAndName(worker, person));
                return RedirectToAction("Index", "Workers");
            }
            var posts = post.SwapPost(editWorker.WorkerPostId);
            ViewBag.Posts = new SelectList(posts, "Id", "PostName");
            return View(editWorker);
        }
    }
}