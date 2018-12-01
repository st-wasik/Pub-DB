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
    public class WarehousesStocksController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: WarehousesStocks
        public ActionResult Index()
        {
            var warehousesStock = db.WarehousesStock.Include(w => w.Products).Include(w => w.Warehouses);
            return View(warehousesStock.ToList());
        }

        // GET: WarehousesStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStock warehousesStock = db.WarehousesStock.Find(id);
            if (warehousesStock == null)
            {
                return HttpNotFound();
            }
            return View(warehousesStock);
        }

        // GET: WarehousesStocks/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.Products, "id", "name");
            ViewBag.warehouse_id = new SelectList(db.Warehouses, "id", "name");
            return View();
        }

        // POST: WarehousesStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,warehouse_id,product_id,quantity")] WarehousesStock warehousesStock)
        {
            if (ModelState.IsValid)
            {
                db.WarehousesStock.Add(warehousesStock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.Products, "id", "name", warehousesStock.product_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouses, "id", "name", warehousesStock.warehouse_id);
            return View(warehousesStock);
        }

        // GET: WarehousesStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStock warehousesStock = db.WarehousesStock.Find(id);
            if (warehousesStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.Products, "id", "name", warehousesStock.product_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouses, "id", "name", warehousesStock.warehouse_id);
            return View(warehousesStock);
        }

        // POST: WarehousesStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,warehouse_id,product_id,quantity")] WarehousesStock warehousesStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehousesStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.Products, "id", "name", warehousesStock.product_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouses, "id", "name", warehousesStock.warehouse_id);
            return View(warehousesStock);
        }

        // GET: WarehousesStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehousesStock warehousesStock = db.WarehousesStock.Find(id);
            if (warehousesStock == null)
            {
                return HttpNotFound();
            }
            return View(warehousesStock);
        }

        // POST: WarehousesStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehousesStock warehousesStock = db.WarehousesStock.Find(id);
            db.WarehousesStock.Remove(warehousesStock);
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
