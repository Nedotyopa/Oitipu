using ToplivoCodeFirst.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ToplivoCodeFirst.Controllers
{
    public class JQGridTanksController : Controller
    {
        //
        // GET: /JQGridTanks/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetTanks(string sidx, string sord, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ToplivoContext db = new ToplivoContext();
            sord = (sord == null) ? "" : sord;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var tanks = db.Tanks.Select(
                    t => new
                    {
                        t.TankID,
                        t.TankType,
                        t.TankVolume,
                        t.TankWeight,
                        t.TankMaterial,
                        t.TankPicture
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "TankType":
                        tanks = tanks.Where(t => t.TankType.Contains(searchString));
                        break;
                    case "TankMaterial":
                        tanks = tanks.Where(t => t.TankMaterial.Contains(searchString));
                        break;
                                       
                }
            }
            int totalRecords = tanks.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                tanks = tanks.OrderByDescending(t => t.TankType);
                tanks = tanks.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                tanks = tanks.OrderBy(t => t.TankType);
                tanks = tanks.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = tanks
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "TankID")] Tank Model)
        {
            ToplivoContext db = new ToplivoContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tanks.Add(Model);
                    db.SaveChanges();
                    msg = "Сохранено";
                }
                else
                {
                    msg = "Ошибка валидации";
                }
            }
            catch (Exception ex)
            {
                msg = "Ошибка:" + ex.Message;
            }
            return msg;
        }
        public string Edit(Tank Model)
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
                    msg = "Ошибка валидации";
                }
            }
            catch (Exception ex)
            {
                msg = "Ошибка:" + ex.Message;
            }
            return msg;
        }
        public string Delete(string Id)
        {
            ToplivoContext db = new ToplivoContext();
            Tank tank = db.Tanks.Find(Convert.ToInt32(Id));
            db.Tanks.Remove(tank);
            db.SaveChanges();
            return "Удалено";
        }

    }
}