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
              
            
            //Получаем из БД  100 объектов Operation, при этом в случае необходимости будут подгудаться данные из Tank и Fuel
            IEnumerable<Operation> operations = db.GetNumberItems(100);
            // передаем все объекты в динамическое свойство Operations в ViewBag
            ViewBag.Operations = operations;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}