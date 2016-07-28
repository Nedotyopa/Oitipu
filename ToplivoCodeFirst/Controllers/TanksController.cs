using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToplivoCodeFirst.Models;

namespace ToplivoCodeFirst.Controllers
{
    public class TanksController : Controller
    {
        UnitOfWork unitOfWork;
        public TanksController()
        {
            // создаем экземпляр класса UnitOfWork, через свойства которого получим доступ к репозитариям 
            unitOfWork = new UnitOfWork();

        }

        // GET: Tanks
        public ActionResult Index()
        {
            return View(unitOfWork.Tanks.GetAll());
        }

        // GET: Tanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = unitOfWork.Tanks.Get((int)id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // GET: Tanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tanks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TankID,TankType,TankWeight,TankVolume,TankMaterial,TankPicture")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Tanks.Create(tank);

                unitOfWork.Tanks.Save();
                return RedirectToAction("Index");
            }

            return View(tank);
        }

        // GET: Tanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = unitOfWork.Tanks.Get((int)id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // POST: Tanks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TankID,TankType,TankWeight,TankVolume,TankMaterial,TankPicture")] Tank tank)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Tanks.Update(tank);
                unitOfWork.Tanks.Save();
                return RedirectToAction("Index");
            }
            return View(tank);
        }

        // GET: Tanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tank tank = unitOfWork.Tanks.Get((int)id);
            if (tank == null)
            {
                return HttpNotFound();
            }
            return View(tank);
        }

        // POST: Tanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tank tank = unitOfWork.Tanks.Get((int)id);
            unitOfWork.Tanks.Delete(id);
            unitOfWork.Tanks.Save();
            return RedirectToAction("Index");
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
