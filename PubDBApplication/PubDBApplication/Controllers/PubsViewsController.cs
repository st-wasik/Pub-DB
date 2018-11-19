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
    public class PubsViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: PubsViews
        public ActionResult Index()
        {
            return View(db.PubsView.ToList());
        }

        // GET: PubsViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PubsView pubsView = db.PubsView.Find(id);
            if (pubsView == null)
            {
                return HttpNotFound();
            }
            return View(pubsView);
        }

        // GET: PubsViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PubsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,e_mail,telephone_no,street,building_no,postal_code,city")] PubsView pubsView)
        {
            if (ModelState.IsValid)
            {
                db.PubsView.Add(pubsView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pubsView);
        }

        // GET: PubsViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PubsView pubsView = db.PubsView.Find(id);
            if (pubsView == null)
            {
                return HttpNotFound();
            }
            return View(pubsView);
        }

        // POST: PubsViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,e_mail,telephone_no,street,building_no,postal_code,city")] PubsView pubsView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pubsView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pubsView);
        }

        // GET: PubsViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PubsView pubsView = db.PubsView.Find(id);
            if (pubsView == null)
            {
                return HttpNotFound();
            }
            return View(pubsView);
        }

        // POST: PubsViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PubsView pubsView = db.PubsView.Find(id);
            db.PubsView.Remove(pubsView);
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
