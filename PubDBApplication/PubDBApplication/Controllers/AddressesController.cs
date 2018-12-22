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
    public class AddressesController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: Addresses
        public ActionResult Index()
        {
            return View(db.Address.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,building_no,street,city,postal_code")] Address address)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Exception = null;
                string msg = null;

                db.Address.Add(address);

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
                    return View(address);
                }

                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,building_no,street,city,postal_code,RowVersion")] Address address)
        {
            ViewBag.Exception = null;
            string msg = null;

            if (ModelState.IsValid)
            {

                var entity = db.Address.Single(p => p.id == address.id);

                if (entity.RowVersion != address.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again.";
                    entity.street = "adsasdasdasd";
                    return RedirectToAction("Edit");
                }

                entity.RowVersion++;
                entity.postal_code = address.postal_code;
                entity.building_no = address.building_no;
                entity.street = address.street;
                entity.city = address.city;

                db.Entry(entity).State = EntityState.Modified;

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
                    return View(address);
                }
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Address.Find(id);

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Exception = null;
            string msg = null;

            Address address = db.Address.Find(id);
            if (address == null)
            {
                ViewBag.Exception = "Cannot find specified Address. Probably it was deleted by another user.";
                return View();
            }
            db.Address.Remove(address);
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
                return View(address);
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
