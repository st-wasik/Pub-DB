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
    public class ProductsViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: ProductsViews
        public ActionResult Index()
        {
            return View(db.ProductsView.ToList());
        }

        // GET: ProductsViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsView productsView = db.ProductsView.SingleOrDefault(m => m.id == id);
            if (productsView == null)
            {
                return HttpNotFound();
            }
            return View(productsView);
        }

        // GET: ProductsViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,producer_name,price,alcohol_percentage,volume")] ProductsView productsView)
        {
            if (ModelState.IsValid)
            {
                db.ProductsView.Add(productsView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productsView);
        }

        // GET: ProductsViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsView productsView = db.ProductsView.SingleOrDefault(m => m.id == id);
            if (productsView == null)
            {
                return HttpNotFound();
            }
            return View(productsView);
        }

        // POST: ProductsViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,producer_name,price,alcohol_percentage,volume")] ProductsView productsView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productsView);
        }

        // GET: ProductsViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsView productsView = db.ProductsView.Find(id);
            if (productsView == null)
            {
                return HttpNotFound();
            }
            return View(productsView);
        }

        // POST: ProductsViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductsView productsView = db.ProductsView.Find(id);
            db.ProductsView.Remove(productsView);
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
