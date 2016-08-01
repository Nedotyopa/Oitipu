using PagedList;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Controllers
{
    public class OperationsController : Controller
    {
        UnitOfWork unitOfWork;
        public PageInfo pageinfo;
        public OperationsController()
        {
            // создаем экземпляр класса UnitOfWork, через свойства которого получим доступ к репозитариям 
            unitOfWork = new UnitOfWork();
            int page = 1;
            pageinfo = new PageInfo { PageNumber = page, PageSize = 20, TotalItems = 0 };
        }

        // GET: Operations
        public ActionResult Index(int page=1, string strTankTypeFind = "", string strFuelTypeFind = "")
        {
            int pageSize = pageinfo.PageSize;
            int pageNumber = page;
            IEnumerable<Operation> operations = unitOfWork.Operations.Find(t => ((t.Tank.TankType.Contains(strTankTypeFind)))&(t.Fuel.FuelType.Contains(strFuelTypeFind)));

            Session["OperationPage"] = page;
            Session["strTankTypeFind"] = strTankTypeFind; Session["strFuelTypeFind"] = strFuelTypeFind;
            return View(operations.ToPagedList(pageNumber, pageSize));
        }

        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == -1) return RedirectToIndex();

            Operation operation = unitOfWork.Operations.Get((int)id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            return View(operation);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            ViewBag.FuelID = new SelectList(unitOfWork.Fuels.GetAll(), "FuelID", "FuelType");
            ViewBag.TankID = new SelectList(unitOfWork.Tanks.GetAll(), "TankID", "TankType");
            return View();
        }

        // POST: Operations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operation operation)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Operations.Create(operation);
                unitOfWork.Operations.Save();
                return RedirectToAction("Index");
            }

            ViewBag.FuelID = new SelectList(unitOfWork.Fuels.GetAll(), "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(unitOfWork.Tanks.GetAll(), "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == -1) return RedirectToIndex();

            Operation operation = unitOfWork.Operations.Get((int)id);
            if (operation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuelID = new SelectList(unitOfWork.Fuels.GetAll(), "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(unitOfWork.Tanks.GetAll(), "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // POST: Operations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Operation operation)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Operations.Update(operation);
                unitOfWork.Operations.Save();
                return RedirectToAction("Index");
            }
            ViewBag.FuelID = new SelectList(unitOfWork.Fuels.GetAll(), "FuelID", "FuelType", operation.FuelID);
            ViewBag.TankID = new SelectList(unitOfWork.Tanks.GetAll(), "TankID", "TankType", operation.TankID);
            return View(operation);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operation operation = unitOfWork.Operations.Get((int)id);
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
            unitOfWork.Operations.Delete(id);
            unitOfWork.Operations.Save();
            return RedirectToAction("Index");
        }

        public ActionResult RedirectToIndex()
        {
            int page = (int)Session["OperationPage"];
            string strTankTypeFind = (string)Session["strTankTypeFind"];
            string strFuelTypeFind = (string)Session["strFuelTypeFind"];

            IEnumerable<Operation> operations = unitOfWork.Operations.Find(t => ((t.Tank.TankType.Contains(strTankTypeFind))&((t.Fuel.FuelType.Contains(strFuelTypeFind)))));
            return View("Index", operations.ToPagedList(page, pageinfo.PageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
