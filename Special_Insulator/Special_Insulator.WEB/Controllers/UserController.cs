using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserBusiness userData;

        public UserController(IUserBusiness userData)
        {
            this.userData = userData;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(userData.GetAllUsers());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditRoles(int Id,string type)
        {
            if(type != null && Id != 0)
            {
                userData.EditRoles(Id,type);
            }
            return RedirectToAction("Index", "User");
        }
    }
}