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
    public class OrderDetailsViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: OrderDetailsViews
        public ActionResult Index()
        {
            return View(db.OrderDetailsView.ToList());
        }

        // GET: OrderDetailsViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsView orderDetailsView = db.OrderDetailsView.Find(id);
            if (orderDetailsView == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsView);
        }

        // GET: OrderDetailsViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,order_id,quantity,product_name")] OrderDetailsView orderDetailsView)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetailsView.Add(orderDetailsView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderDetailsView);
        }

        // GET: OrderDetailsViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsView orderDetailsView = db.OrderDetailsView.Find(id);
            if (orderDetailsView == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsView);
        }

        // POST: OrderDetailsViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,order_id,quantity,product_name")] OrderDetailsView orderDetailsView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetailsView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderDetailsView);
        }

        // GET: OrderDetailsViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsView orderDetailsView = db.OrderDetailsView.Find(id);
            if (orderDetailsView == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsView);
        }

        // POST: OrderDetailsViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetailsView orderDetailsView = db.OrderDetailsView.Find(id);
            db.OrderDetailsView.Remove(orderDetailsView);
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
