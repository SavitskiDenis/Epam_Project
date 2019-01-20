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
        IWorkerService workerService;
        IPostService postSevice;

        public WorkersController(IWorkerService data,IPostService post)
        {
            this.workerService = data;
            this.postSevice = post;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index(string error = "")
        {
            var workers = workerService.GetAllWorkers();
            if (workers != null)
            {
                ViewBag.Error = error;
                return View(workers);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddWorker()
        {
            var posts = postSevice.GetAllPosts();
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

                if(workerService.AddWorker(addWorker, addPerson))
                {
                    return RedirectToAction("Index", "Edit");
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при добавлении данных!" });
            }
            var posts = postSevice.GetAllPosts();
            if(posts != null)
            {
                ViewBag.Posts = new SelectList(posts, "Id", "PostName");
                return View(worker);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteWorker(int? Id)
        {
            if(!workerService.IsUsing(Id))
            {
                if (workerService.DeleteWorkerById(Id))
                {
                    return RedirectToAction("Index", "Workers");
                }
                return RedirectToAction("InformationError", "Error", new { message = "Ошибка удаления. Проверьте вводимые данные!" });
            }
            return RedirectToAction("Index","Workers",new { error ="Невозможно удалить, т.к. данные сотрудник используется"});
            
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditWorker(int? Id)
        {
            WorkerAndName myWorker = workerService.GetWorkerById(Id);
            if(myWorker != null)
            {
                var posts = postSevice.SwapPost(myWorker.Worker.WorkerPost.Id);
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
                if(workerService.EditWorker(new WorkerAndName(worker, person)))
                {
                    return RedirectToAction("Index", "Workers");
                }
                return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });

            }
            var posts = postSevice.SwapPost(editWorker.WorkerPostId);
            ViewBag.Posts = new SelectList(posts, "Id", "PostName");
            return View(editWorker);
        }
    }
}