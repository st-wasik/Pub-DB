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
    public class ProducersViewsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: ProducersViews
        public ActionResult Index()
        {
            return View(db.ProducersView.ToList());
        }

        // GET: ProducersViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducersView producersView = db.ProducersView.Find(id);
            if (producersView == null)
            {
                return HttpNotFound();
            }
            return View(producersView);
        }

        // GET: ProducersViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,e_mail,telephone_no,street,building_no,postal_code,city")] ProducersView producersView)
        {
            if (ModelState.IsValid)
            {
                db.ProducersView.Add(producersView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producersView);
        }

        // GET: ProducersViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducersView producersView = db.ProducersView.Find(id);
            if (producersView == null)
            {
                return HttpNotFound();
            }
            return View(producersView);
        }

        // POST: ProducersViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,e_mail,telephone_no,street,building_no,postal_code,city")] ProducersView producersView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producersView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producersView);
        }

        // GET: ProducersViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProducersView producersView = db.ProducersView.Find(id);
            if (producersView == null)
            {
                return HttpNotFound();
            }
            return View(producersView);
        }

        // POST: ProducersViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProducersView producersView = db.ProducersView.Find(id);
            db.ProducersView.Remove(producersView);
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
