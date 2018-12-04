using Common.Entity;
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
        public ActionResult Index()
        {
            //List<Detainee> detainees = new List<Detainee>
            //{
            //    new Detainee
            //    {
            //        FullName = "Иванов Иван Иванович",
            //        BornDate = new DateTime(1971, 1, 1),
            //        Status = Marital_status.Divorced,
            //        Additional_information = "",
            //        Address = "г.Могилев,ул.Ленина,д.17,кв.4",
            //        Phone = "+375299113118",
            //        Photo = Url.Content("http://www.garant-barnaul.ru/company_news/news_2015/LoorI.I..jpg"),
            //        Workplace = "Нет"
            //    },
            //    new Detainee
            //    {
            //        FullName = "Павлова Екатериан Степановна",
            //        BornDate = new DateTime(1971, 3, 11),
            //        Status = Marital_status.Married,
            //        Additional_information = "",
            //        Address = "г.Могилев,ул.Ленина,д.7,кв.12",
            //        Phone = "+375293111734",
            //        Photo = Url.Content("http://old.newcinemaschool.com/upload/iblock/760/76080db7efcfad1e3ce965420c2d64c4.jpg"),
            //        Workplace = "Нет"
            //    }

            //};
            return View(data.GetAllDetainees());
        }
    }
}