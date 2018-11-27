using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PubDBApplication.Models;

namespace PubDBApplication.Controllers
{
    public class WarehousesStockViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: WarehousesStockViews
        public ActionResult Index()
        {
            return View(db.WarehousesStockView.ToList());
        }

        // GET: WarehousesStockViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStockView warehousesStockView = db.WarehousesStockView.Find(id);
            if (warehousesStockView == null)
            {
                return HttpNotFound();
            }
            return View(warehousesStockView);
        }

        // GET: WarehousesStockViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WarehousesStockViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,warehouse_name,product_name,quantity")] WarehousesStockView warehousesStockView)
        {
            if (ModelState.IsValid)
            {
                db.WarehousesStockView.Add(warehousesStockView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehousesStockView);
        }

        // GET: WarehousesStockViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStockView warehousesStockView = db.WarehousesStockView.Find(id);
            if (warehousesStockView == null)
            {
                return HttpNotFound();
            }
            return View(warehousesStockView);
        }

        // POST: WarehousesStockViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,warehouse_name,product_name,quantity")] WarehousesStockView warehousesStockView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehousesStockView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehousesStockView);
        }

        // GET: WarehousesStockViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStockView warehousesStockView = db.WarehousesStockView.Find(id);
            if (warehousesStockView == null)
            {
                return HttpNotFound();
            }
            return View(warehousesStockView);
        }

        // POST: WarehousesStockViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehousesStockView warehousesStockView = db.WarehousesStockView.Find(id);
            db.WarehousesStockView.Remove(warehousesStockView);
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
