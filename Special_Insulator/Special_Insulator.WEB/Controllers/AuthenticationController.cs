using Special_Insulator.WEB.Models;
using System.Web.Mvc;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserService userData;

        public AuthenticationController(IUserService userData)
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