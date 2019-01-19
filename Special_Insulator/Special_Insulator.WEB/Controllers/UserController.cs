using Special_Insulator.WEB.Models;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Specila_Insultor.BLL;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class UserController : Controller
    {
        private IUserService userData;

        private AuthenticationPrincipal MyUser { get { return HttpContext.User as AuthenticationPrincipal; } }

        public UserController(IUserService userData)
        {
            this.userData = userData;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var collection = userData.GetAllUsers();
            if (collection != null)
            {
                return View(collection);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
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

        [Authorize]
        public ActionResult UserProfile()
        {
            User user = new User {
                Id = MyUser.Id,
                Login = MyUser.Login,
                Email = MyUser.Email,
            };

            return View(user);
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditUserInfo()
        {
            var user = userData.GetUserByLoginAndEmail(MyUser.Login,MyUser.Email);
            if(user != null)
            {
                var model = Mapper.MapToItem<User, UserEditModel>(user);
                model.OldLogin = user.Login;
                return View(model);
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при получении данных!" });
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditUserInfo(UserEditModel user)
        {
            if(ModelState.IsValid)
            {
                if (userData.checkUserAndGet(new User { Login = user.OldLogin, Password =  user.OldPassword}) != null)
                {
                    var _newUser = Mapper.MapToItem<UserEditModel,User>(user);
                    _newUser.Password = user.NewPassword;
                    if(userData.EditUserInfo(_newUser))
                    {
                        return RedirectToAction("LogOut", "Authentication");
                    }
                    return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при изменении данных!" });
                }
                ViewBag.Error = "Не верный пароль!";
            }
            return View(user);
            
        }

        [Authorize(Roles ="Admin")]
        public ActionResult DeleteUser(int? Id)
        {
            if(userData.DeleteUser(Id))
            {
                return RedirectToAction("Index","User");
            }
            return RedirectToAction("InformationError", "Error", new { message = "Произошла ошибка при удалении данных!" });
        }
    }
}