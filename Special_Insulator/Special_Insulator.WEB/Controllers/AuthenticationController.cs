using Special_Insulator.WEB.Models;
using System.Web.Mvc;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserService userService;

        public AuthenticationController(IUserService userData)
        {
            this.userService = userData;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = Mapper.MapToItem<UserLoginModel, User>(model);
                user = userService.checkUserAndGet(user);
                if (user != null)
                {
                    userService.AddCookies(user);
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
        public ActionResult Registration(UserRegistrationModel model)
        {
            if(ModelState.IsValid)
            {
                User user = Mapper.MapToItem<UserRegistrationModel, User>(model);
                if(userService.AddUser(user))
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
            userService.DeleteCookies();
            return RedirectToAction("Index","Home");
        }
    }
}