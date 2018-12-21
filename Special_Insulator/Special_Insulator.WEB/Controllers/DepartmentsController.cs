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
    }
}