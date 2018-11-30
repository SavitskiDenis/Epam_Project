using Special_Insulator.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class AuthenticationController : Controller
    {

        public ActionResult Login()
        {
            return View();
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
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}