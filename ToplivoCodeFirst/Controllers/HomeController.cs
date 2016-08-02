﻿using System.Web.Mvc;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Controllers
{

    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        TransferData transferdata=new TransferData { TankPage=1, FuelPage=1, OperationPage=1, strTankTypeFind="", strFuelTypeFind=""};

        public HomeController()
        {
            // создаем экземпляр класса UnitOfWork, через свойства которого получим доступ к репозитариям 
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index(int pagesize = 20)
        {
            //Инициализация временных переменных сессии для использования разными объектами
            int page = transferdata.OperationPage;
            ViewBag.NumberOperations = pagesize;
            //Получаем из БД  pagesize объектов Operation, при этом будут подгружаться данные из Tank и Fuel
            PagedCollection<Operation> pagedcollection = unitOfWork.Operations.GetNumberItems(t=>true,page, pagesize);
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