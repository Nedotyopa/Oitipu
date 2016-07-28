using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Controllers
{

    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            // создаем экземпляр класса UnitOfWork, через свойства которого получим доступ к репозитариям 
            unitOfWork = new UnitOfWork();
            
        }


        public ActionResult Index(int page = 1, int pagesize = 20)
        {
  
            ViewBag.NumberOperations = pagesize;
            //Получаем из БД  pagesize объектов Operation, при этом будут подгружаться данные из Tank и Fuel
            PagedCollection<Operation> pagedcollection = unitOfWork.Operations.GetNumberItems(page, pagesize);
            // передаем все объекты в динамическое свойство Operations в ViewBag
            ViewBag.Operations = pagedcollection.PagedItems;
            ViewBag.PageInfo = pagedcollection.PageInfo;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Описание приложения";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница с контактыми данными";
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}