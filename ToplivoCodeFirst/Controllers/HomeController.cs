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

        IRepository<Operation> db;
        public HomeController()
        {
            // создаем контекст данных
            db = new OperationRepository();
        }


        public ActionResult Index()
        {

            int NumberOperations = 100;//Количество записей на главной странице
            // передаем значение количества объектов в динамическое свойство NumberOperations

            ViewBag.NumberOperations = NumberOperations;

            //Получаем из БД  100 объектов Operation, при этом в случае необходимости будут подгружаться данные из Tank и Fuel
            var operations = db.GetNumberItems(NumberOperations);
            // передаем все объекты в динамическое свойство Operations в ViewBag
            ViewBag.Operations = operations;
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
    }
}