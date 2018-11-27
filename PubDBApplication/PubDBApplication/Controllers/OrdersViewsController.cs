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
    public class OrdersViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: OrdersViews
        public ActionResult Index()
        {
            return View(db.OrdersView.ToList());
        }

        // GET: OrdersViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersView ordersView = db.OrdersView.SingleOrDefault(m => m.id == id);
            ViewBag.odView = (from x in db.OrderDetailsView where x.order_id == id select x).ToList();
            if (ordersView == null)
            {
                return HttpNotFound();
            }
            return View(ordersView);
        }

        // GET: OrdersViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            if (ModelState.IsValid)
            {
                db.OrdersView.Add(ordersView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordersView);
        }

        // GET: OrdersViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersView ordersView = db.OrdersView.SingleOrDefault(m => m.id == id);
            if (ordersView == null)
            {
                return HttpNotFound();
            }
            return View(ordersView);
        }

        // POST: OrdersViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordersView);
        }

        // GET: OrdersViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersView ordersView = db.OrdersView.Find(id);
            if (ordersView == null)
            {
                return HttpNotFound();
            }
            return View(ordersView);
        }

        // POST: OrdersViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersView ordersView = db.OrdersView.Find(id);
            db.OrdersView.Remove(ordersView);
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
