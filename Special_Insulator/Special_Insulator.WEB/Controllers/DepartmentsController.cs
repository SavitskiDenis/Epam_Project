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
    public class DepartmentsController : Controller
    {
        IDepartmentBusiness data;

        public DepartmentsController(IDepartmentBusiness data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            return View(data.GetAllDepartments());
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
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
        public ActionResult EditDepartment(int Id)
        {
            DepartmentMod department = Mapper.MapToItem<Department,DepartmentMod>(data.GetDepartmnetnById(Id));
            return View(department);
        }

        [HttpPost]
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

        public ActionResult DeleteDepartment(int Id)
        {
            data.DeleteDepartmentsById(Id);
            return RedirectToAction("Index","Departments");
        }

    }
}