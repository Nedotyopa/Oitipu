using System;
using System.Linq;
using System.Web.Mvc;
using ToplivoCodeFirst.Models;
using System.Data.Entity;

namespace ToplivoCodeFirst.Controllers
{
    public class JQGridFuelsController : Controller
    {
        // GET: JQGridFuels
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetFuels(string sidx, string sort, int page, int rows)
        {
            ToplivoContext db = new ToplivoContext();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var FuelList = db.Fuels.Select(
                    t => new
                    {
                        t.FuelID,
                        t.FuelType,
                        t.FuelDensity
                    });
            int totalRecords = FuelList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                FuelList = FuelList.OrderByDescending(t => t.FuelType);
                FuelList = FuelList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                FuelList = FuelList.OrderBy(t => t.FuelType);
                FuelList = FuelList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = FuelList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public string Create([Bind(Exclude = "FuelID")] Fuel Model)
        {
            ToplivoContext db = new ToplivoContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Fuels.Add(Model);
                    db.SaveChanges();
                    msg = "Запись сохранена";
                }
                else
                {
                    msg = "Модель не прошла валидацию";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Fuel Model)
        {
            ToplivoContext db = new ToplivoContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Запись сохранена";
                }
                else
                {
                    msg = "Модель не прошла валидацию";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(string id)
        {
            ToplivoContext db = new ToplivoContext();
            Fuel fuel = db.Fuels.Find(Convert.ToInt32(id));
            db.Fuels.Remove(fuel);
            db.SaveChanges();
            return "Запись удалена";
        }

    }
}