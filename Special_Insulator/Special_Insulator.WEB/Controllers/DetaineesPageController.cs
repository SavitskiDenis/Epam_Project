﻿using Common.Entity;
using Specila_Insultor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Special_Insulator.WEB.Controllers
{
    public class DetaineesPageController : Controller
    {
        private IBusinessLayer data;

        public DetaineesPageController(IBusinessLayer data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            return View(data.GetAllDetainees());
        }
    }
}