using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using System.Linq;
using System.Web.Mvc;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class WorkersController : Controller
    {
        IWorkerService data;
        IPostService post;

        public WorkersController(IWorkerService data,IPostService post)
        {
            this.data = data;
            this.post = post;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index()
        {
            var workers = data.GetAllWorkers();
            if (workers != null)
            {
                return View(workers);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddWorker()
        {
            var posts = post.GetAllPosts();
            if(posts != null && posts.Count>0)
            {
                ViewBag.Posts = new SelectList(posts, "Id", "PostName");
                return View();
            }
            else if(posts.Count == 0)
            {
                return RedirectToAction("Index","Edit", new { error = "Необходимо добавить должности!" });
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddWorker(WorkerWithNameModel worker)
        {
            if (ModelState.IsValid)
            {
                var addWorker = Mapper.MapToItem<WorkerWithNameModel, Worker>(worker);
                var addPerson = Mapper.MapToItem<WorkerWithNameModel, Person>(worker);
                addWorker.WorkerPost =new Post {Id =  worker.WorkerPostId };

                if(data.AddWorker(addWorker, addPerson))
                {
                    return RedirectToAction("Index", "Edit");
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при добавлении данных!" });
            }
            var posts = post.GetAllPosts();
            if(posts != null)
            {
                ViewBag.Posts = new SelectList(posts, "Id", "PostName");
                return View(worker);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        public ActionResult DeleteWorker(int? Id)
        {
            if(data.DeleteWorkerById(Id))
            {
                return RedirectToAction("Index", "Workers");
            }
            return RedirectToAction("InformationError", "Error", new { message = "Ошибка удаления. Проверьте вводимые данные!" });
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditWorker(int? Id)
        {
            WorkerAndName myWorker = data.GetWorkerById(Id);
            if(myWorker != null)
            {
                var posts = post.SwapPost(myWorker.Worker.WorkerPost.Id);
                if(posts != null)
                {
                    ViewBag.Posts = new SelectList(posts, "Id", "PostName");
                    WorkerWithNameModel editWorker = Mapper.MapToItem<Person, WorkerWithNameModel>(myWorker.Person);
                    editWorker = Mapper.UpdateInfo(editWorker, myWorker.Worker);
                    editWorker.WorkerPostId = myWorker.Worker.WorkerPost.Id;
                    return View(editWorker);
                }
                
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных. Проверьте вводимые параметры!" });
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditWorker(WorkerWithNameModel editWorker)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.MapToItem<WorkerWithNameModel, Person>(editWorker);
                var worker = Mapper.MapToItem<WorkerWithNameModel, Worker>(editWorker);
                worker.WorkerPost = new Post { Id = editWorker.WorkerPostId};
                if(data.EditWorker(new WorkerAndName(worker, person)))
                {
                    return RedirectToAction("Index", "Workers");
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });

            }
            var posts = post.SwapPost(editWorker.WorkerPostId);
            ViewBag.Posts = new SelectList(posts, "Id", "PostName");
            return View(editWorker);
        }
    }
}