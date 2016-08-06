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


        public JsonResult GetFuels(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ToplivoContext db = new ToplivoContext();
            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var fuels = db.Fuels.Select(
                    t => new
                    {
                        t.FuelID,
                        t.FuelType,
                        t.FuelDensity
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "FuelType":
                        fuels = fuels.Where(t => t.FuelType.Contains(searchString));
                        break;
                    
                }
            }


            int totalRecords = fuels.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                fuels = fuels.OrderByDescending(t => t.FuelType);
                fuels = fuels.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                fuels = fuels.OrderBy(t => t.FuelType);
                fuels = fuels.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = fuels
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
                    msg = "Сохранено";
                }
                else
                {
                    msg = "Модель не прошла валидацию";
                }
            }
            catch (Exception ex)
            {
                msg = "Ошибка:" + ex.Message;
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
                    msg = "Сохранено";
                }
                else
                {
                    msg = "Модель не прошла валидацию";
                }
            }
            catch (Exception ex)
            {
                msg = "Ошибка:" + ex.Message;
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