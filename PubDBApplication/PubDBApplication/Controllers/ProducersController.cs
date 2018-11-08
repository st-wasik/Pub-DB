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
    public class ProducersController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: Producers
        public ActionResult Index()
        {
            var producers = db.Producers.Include(p => p.Address);
            return View(producers.ToList());
        }

        // GET: Producers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producers producers = db.Producers.Find(id);
            if (producers == null)
            {
                return HttpNotFound();
            }
            return View(producers);
        }

        // GET: Producers/Create
        public ActionResult Create()
        {
            ViewBag.adress_id = new SelectList(db.Address, "id", "street");
            return View();
        }

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,adress_id")] Producers producers)
        {
            if (ModelState.IsValid)
            {
                db.Producers.Add(producers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adress_id = new SelectList(db.Address, "id", "street", producers.adress_id);
            return View(producers);
        }

        // GET: Producers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producers producers = db.Producers.Find(id);
            if (producers == null)
            {
                return HttpNotFound();
            }
            ViewBag.adress_id = new SelectList(db.Address, "id", "street", producers.adress_id);
            return View(producers);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,adress_id")] Producers producers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adress_id = new SelectList(db.Address, "id", "street", producers.adress_id);
            return View(producers);
        }

        // GET: Producers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producers producers = db.Producers.Find(id);
            if (producers == null)
            {
                return HttpNotFound();
            }
            return View(producers);
        }

        // POST: Producers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producers producers = db.Producers.Find(id);
            db.Producers.Remove(producers);
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
