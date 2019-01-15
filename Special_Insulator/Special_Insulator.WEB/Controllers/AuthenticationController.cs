using Special_Insulator.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Entity;
using Common.Mapper;
using Specila_Insultor.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserBusiness userData;

        public AuthenticationController(IUserBusiness userData)
        {
            this.userData = userData;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.MapToItem<UserLogin, User>(model);
                user = userData.checkUserAndGet(user);
                if (user != null)
                {
                    userData.AddCookies(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Проверьте вводимые данные";
                }

            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserRegistration model)
        {
            if(ModelState.IsValid)
            {
                User user = Mapper.MapToItem<UserRegistration, User>(model);
                if(userData.AddUser(user))
                {
                    return RedirectToAction("Login", "Authentication");
                }
                ViewBag.Error = "Пользователь с таким логином уже существует";
            }
            return View(model);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            userData.DeleteCookies();
            return RedirectToAction("Index","Home");
        }
    }
}