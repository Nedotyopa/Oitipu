using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Controllers
{
    public class OperationsController : Controller
    {
        private ToplivoContext db = new ToplivoContext();

        // GET: Operations
        public ActionResult Index(int page=1)
        {

            int pageSize = 3;
            int pageNumber = page;
            var operations = db.Operations.Include(o => o.Fuel).Include(o => o.Tank).OrderBy(o=>o.OperationID);
            return View(operations.ToPagedList(pageNumber, pageSize));

        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType");
            ViewBag.TankID = new SelectList(db.Tanks, "TankID", "TankType");
            return View();
        }

        // POST: Operations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(db.Tanks, "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(db.Tanks, "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OperationID,FuelID,TankID,Inc_Exp,Date")] Operation operation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuelID = new SelectList(db.Fuels, "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(db.Tanks, "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = db.Operations.Find(id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operation operation = db.Operations.Find(id);
            db.Operations.Remove(operation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
