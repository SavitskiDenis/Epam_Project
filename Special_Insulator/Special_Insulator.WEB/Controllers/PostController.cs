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
    public class PostController : Controller
    {
        IPostBusiness postData;

        public PostController(IPostBusiness postData)
        {
            this.postData = postData;
        }

        [Authorize(Roles = "Editor")]
        public ActionResult Index()
        {
            return View(postData.GetAllPosts());
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddPost()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddPost(PostMod model)
        {
            if (ModelState.IsValid)
            {
                Post post = Mapper.MapToItem<PostMod,Post>(model);
                postData.AddPost(post);
                return RedirectToAction("Index", "Edit");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditPost(int Id)
        {
            PostMod post = Mapper.MapToItem<Post,PostMod>(postData.GetPostById(Id));
            return View(post);
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditPost(PostMod model)
        {
            if (ModelState.IsValid)
            {
                Post post = Mapper.MapToItem<PostMod, Post>(model);
                postData.EditPost(post);
                return RedirectToAction("Index", "Post");
            }
            return View(model);
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeletePost(int Id)
        {
            postData.DeletePostById(Id);
            return RedirectToAction("Index", "Post");
        }
    }
}