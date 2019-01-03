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
    public class PubsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: Pubs
        public ActionResult Index()
        {
            var pubs = db.Pubs.Include(p => p.Address);
            return View(pubs.ToList());
        }

        // GET: Pubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pubs pubs = db.Pubs.Find(id);
            if (pubs == null)
            {
                return HttpNotFound();
            }
            return View(pubs);
        }

        // GET: Pubs/Create
        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var entities = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
            foreach (var i in entities)
            {
                list.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
            }
            ViewBag.adress_id = new SelectList(list, "Value", "Text", 1);
            return View();
        }

        // POST: Pubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,adress_id,e_mail,telephone_no")] Pubs pubs)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                db.Pubs.Add(pubs);
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
                    List<SelectListItem> list2 = new List<SelectListItem>();
                    var entities2 = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
                    foreach (var i in entities2)
                    {
                        list2.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
                    }
                    ViewBag.adress_id = new SelectList(list2, "Value", "Text", 1);
                    return View(pubs);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Pubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pubs pubs = db.Pubs.Find(id);
            if (pubs == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> list = new List<SelectListItem>();
            var entities = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
            foreach (var i in entities)
            {
                list.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
            }
            ViewBag.adress_id = new SelectList(list, "Value", "Text", 1);
            return View(pubs);
        }

        // POST: Pubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,adress_id,e_mail,telephone_no,RowVersion")] Pubs pubs)
        {

            ViewBag.Exception = null;
            string msg = null;

            if (ModelState.IsValid)
            {
                var entity = db.Pubs.Single(p => p.id == pubs.id);

                if (entity.RowVersion != pubs.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again.";
                    return RedirectToAction("Edit");
                }
                entity.RowVersion++;
                entity.name = pubs.name;
                entity.adress_id = pubs.adress_id;
                entity.e_mail = pubs.e_mail;
                entity.telephone_no = pubs.telephone_no;
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
                    List<SelectListItem> list2 = new List<SelectListItem>();
                    var entities2 = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
                    foreach (var i in entities2)
                    {
                        list2.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
                    }
                    ViewBag.adress_id = new SelectList(list2, "Value", "Text", 1);
                    return View(pubs);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Pubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pubs pubs = db.Pubs.Find(id);
            ViewBag.pub_address = (from a in db.Address where a.id == pubs.adress_id select a).First();
            if (pubs == null)
            {
                return HttpNotFound();
            }
            return View(pubs);
        }

        // POST: Pubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Exception = null;
            string msg = null;
            Pubs pubs = db.Pubs.Find(id);
            db.Pubs.Remove(pubs);
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
                ViewBag.pub_address = (from a in db.Address where a.id == pubs.adress_id select a).First();
                return View(pubs);
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
