﻿using System;
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
    public class WarehousesController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: Warehouses
        public ActionResult Index()
        {
            return View(db.Warehouses.ToList());
        }

        // GET: Warehouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouses warehouses = db.Warehouses.Find(id);
            if (warehouses == null)
            {
                return HttpNotFound();
            }
            return View(warehouses);
        }

        // GET: Warehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Warehouses warehouses)
        {
            if (ModelState.IsValid)
            {
                db.Warehouses.Add(warehouses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouses);
        }

        // GET: Warehouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouses warehouses = db.Warehouses.Find(id);
            if (warehouses == null)
            {
                return HttpNotFound();
            }
            return View(warehouses);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Warehouses warehouses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouses);
        }

        // GET: Warehouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouses warehouses = db.Warehouses.Find(id);
            if (warehouses == null)
            {
                return HttpNotFound();
            }
            return View(warehouses);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouses warehouses = db.Warehouses.Find(id);
            db.Warehouses.Remove(warehouses);
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
