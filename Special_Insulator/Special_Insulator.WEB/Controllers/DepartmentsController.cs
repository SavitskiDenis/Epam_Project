using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Mapper;
using Special_Insulator.WEB.Models;
using System.Web.Mvc;
using SpecialInsulator.BLL.Interfaces;

namespace Special_Insulator.WEB.Controllers
{
    public class DepartmentsController : Controller
    {
        IDepartmentService data;

        public DepartmentsController(IDepartmentService data)
        {
            this.data = data;
        }

        [Authorize(Roles ="Editor")]
        public ActionResult Index()
        {
            return View(data.GetAllDepartments());
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult AddDepartment(DepartmentMod department)
        {
            if(ModelState.IsValid)
            {
                var addDepartment = Mapper.MapToItem<DepartmentMod, Department>(department);
                data.AddDepartment(addDepartment);
                return RedirectToAction("Index", "Edit");
            }

            return View(department);
        }

        [HttpGet]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDepartment(int Id)
        {
            DepartmentMod department = Mapper.MapToItem<Department,DepartmentMod>(data.GetDepartmnetnById(Id));
            return View(department);
        }

        [HttpPost]
        [Authorize(Roles = "Editor")]
        public ActionResult EditDepartment(DepartmentMod department)
        {
            if (ModelState.IsValid)
            {
                Department dep = Mapper.MapToItem<DepartmentMod, Department>(department);
                data.EditDepartment(dep);
                return RedirectToAction("Index","Departments");
            }
            return View(department);
        }

        [Authorize(Roles = "Editor")]
        public ActionResult DeleteDepartment(int Id)
        {
            data.DeleteDepartmentsById(Id);
            return RedirectToAction("Index","Departments");
        }

    }
}