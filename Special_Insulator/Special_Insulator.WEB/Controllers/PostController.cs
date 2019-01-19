using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using SpecialInsulator.BLL.Interfaces;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class PostController : Controller
    {
        IPostService postData;

        public PostController(IPostService postData)
        {
            this.postData = postData;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index()
        {
            var posts = postData.GetAllPosts();
            if (posts != null)
            {
                return View(posts);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddPost(PostModel model)
        {
            if (ModelState.IsValid)
            {
                if(postData.IsNewPost(model.PostName))
                {
                    Post post = Mapper.MapToItem<PostModel, Post>(model);
                    postData.AddPost(post);
                    return RedirectToAction("Index", "Edit");
                }
                ViewBag.Error = "Такая должность уже существует";
            }
            
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditPost(int? Id)
        {
            var post = postData.GetPostById(Id);
            if(post != null)
            {
                PostModel model = Mapper.MapToItem<Post, PostModel>(post);
                return View(model);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных. Проверьте вводимые параметры!" });
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditPost(PostModel model)
        {
            if (ModelState.IsValid )
            {
                if(postData.IsNewPost(model.PostName))
                {
                    Post post = Mapper.MapToItem<PostModel, Post>(model);
                    postData.EditPost(post);
                    return RedirectToAction("Index", "Post");
                }
                ViewBag.Error = "Такая должность уже существует";
            }
            return View(model);
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeletePost(int? Id)
        {
            if(postData.DeletePostById(Id))
            {
                return RedirectToAction("Index", "Post");
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при удалении данных. Проверьте вводимые данные!" });
        }
    }
}