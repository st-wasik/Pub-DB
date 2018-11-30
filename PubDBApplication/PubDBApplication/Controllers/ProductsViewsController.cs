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
            ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
            return View();
        }

        // POST: ProductsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,producer_name,price,alcohol_percentage,volume")] ProductsView productsView)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                Products product = new Products
                {
                    name = productsView.name,
                    producer_id = (from p in db.Producers where p.name == productsView.producer_name select p).Single().id,
                    price = productsView.price,
                    alcohol_percentage = productsView.alcohol_percentage,
                    volume = productsView.volume
                };
                db.Products.Add(product);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = "Invalid data";
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;

                    ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
                    return View(productsView);
                }
                return RedirectToAction("Index");
            }
            ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
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
            ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
            return View(productsView);
        }

        // POST: ProductsViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,producer_name,price,alcohol_percentage,volume")] ProductsView productsView)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                Products product = (from p in db.Products where p.id == productsView.id select p).First();

                product.name = productsView.name;
                product.producer_id = (from p in db.Producers where p.name == productsView.producer_name select p).Single().id;
                product.price = productsView.price;
                product.alcohol_percentage = productsView.alcohol_percentage;
                product.volume = productsView.volume;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = "Invalid data";
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;

                    ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
                    return View(productsView);
                }
                return RedirectToAction("Index");
            }
            ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
            return View(productsView);
        }

        // GET: ProductsViews/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ProductsViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Exception = null;
            string msg = null;
            Products product = (from p in db.Products where p.id == id select p).First();

            db.Products.Remove(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    msg = "Invalid data";
                else
                    msg = e.InnerException.InnerException.Message;

                ViewBag.Exception = msg;
                return View(id);
            }

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
