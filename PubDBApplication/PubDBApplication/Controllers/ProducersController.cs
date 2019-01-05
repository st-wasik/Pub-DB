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
            ViewBag.products = (from x in db.Products where x.producer_id == id select x).ToList();
            if (producers == null)
            {
                return HttpNotFound();
            }
            return View(producers);
        }

        // GET: Producers/Create
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

        // POST: Producers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,adress_id,e_mail,telephone_no")] Producers producers)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                db.Producers.Add(producers);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = e.Message;
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
                    return View(producers);
                }
                return RedirectToAction("Index");
            }


            List<SelectListItem> list = new List<SelectListItem>();
            var entities = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
            foreach (var i in entities)
            {
                list.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
            }
            ViewBag.adress_id = new SelectList(list, "Value", "Text", 1);
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
            List<SelectListItem> list = new List<SelectListItem>();
            var entities = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
            foreach (var i in entities)
            {
                list.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
            }
            ViewBag.adress_id = new SelectList(list, "Value", "Text", 1);
            return View(producers);
        }

        // POST: Producers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,adress_id,e_mail,telephone_no,RowVersion")] Producers producers)
        {

            ViewBag.Exception = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                var entity = db.Producers.Single(p => p.id == producers.id);

                if (entity.RowVersion != producers.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again.";
                    return RedirectToAction("Edit");
                }

                entity.RowVersion++;
                entity.name = producers.name;
                entity.adress_id = producers.adress_id;
                entity.e_mail = producers.e_mail;
                entity.telephone_no = producers.telephone_no;

                db.Entry(entity).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = e.Message;
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;
                    List<SelectListItem> list = new List<SelectListItem>();
                    var entities = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
                    foreach (var i in entities)
                    {
                        list.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
                    }
                    ViewBag.adress_id = new SelectList(list, "Value", "Text", 1);
                    return View(producers);
                }

                return RedirectToAction("Index");
            }

            List<SelectListItem> list2 = new List<SelectListItem>();
            var entities2 = (from a in db.Address orderby a.street, a.building_no, a.postal_code, a.city select a).ToList();
            foreach (var i in entities2)
            {
                list2.Add(new SelectListItem { Selected = false, Text = i.ToString(), Value = i.id.ToString() });
            }
            ViewBag.adress_id = new SelectList(list2, "Value", "Text", 1);
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
            ViewBag.producer_address = (from a in db.Address where a.id == producers.adress_id select a).First();
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
            ViewBag.Exception = null;
            string msg = null;
            Producers producers = db.Producers.Find(id);
            db.Producers.Remove(producers);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    msg = e.Message;
                else
                    msg = e.InnerException.InnerException.Message;

                ViewBag.Exception = msg;
                ViewBag.producer_address = (from a in db.Address where a.id == producers.adress_id select a).First();
                return View(producers);
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
