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
        private readonly string OrderInRealization = "In Realization";
        private readonly string OrderInCreation = "In Creation";
        private readonly string OrderCompleted = "Completed";
        private readonly string OrderIncoming = "Incoming";
        private readonly string OrderOutcoming = "Outcoming";

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
        public ActionResult CreateIncoming()
        {
            ViewBag.warehouse_name = new SelectList(db.Warehouses, "name", "name");
            ViewBag.pub_name = new SelectList(db.Pubs, "name", "name");
            ViewBag.Incoming_Outcoming = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Selected = false, Text = "Incoming", Value = "Incoming"},
                new SelectListItem { Selected = false, Text = "Outcoming", Value = "Outcoming"}
            }, "Value", "Text", 1);
            return View();
        }

        // POST: OrdersViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateIncoming([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                Orders order = new Orders
                {
                    warehouse_id = (from w in db.Warehouses where w.name == ordersView.warehouse_name select w).Single().id,
                    pub_id = (from p in db.Pubs where p.name == ordersView.pub_name select p).Single().id,
                    Incoming_Outcoming = OrderIncoming,
                    status = OrderInCreation,
                    date = System.DateTime.Now
                };
                db.Orders.Add(order);
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
                    ViewBag.warehouse_name = new SelectList(db.Warehouses, "name", "name");
                    ViewBag.pub_name = new SelectList(db.Pubs, "name", "name");
                    return View(ordersView);
                }
                return RedirectToAction("Details", new { id = order.id });
            }

            ViewBag.warehouse_name = new SelectList(db.Warehouses, "id", "name");
            ViewBag.pub_name = new SelectList(db.Pubs, "id", "name");
            ViewBag.producer_name = new SelectList(db.Producers, "id", "name");
            return View(ordersView);
        }

        public ActionResult CreateOutcoming()
        {
            ViewBag.warehouse_name = new SelectList(db.Warehouses, "name", "name");
            ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
            return View();
        }

        // POST: OrdersViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOutcoming([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                Orders order = new Orders
                {
                    warehouse_id = (from w in db.Warehouses where w.name == ordersView.warehouse_name select w).Single().id,
                    producer_id = (from p in db.Producers where p.name == ordersView.producer_name select p).Single().id,
                    Incoming_Outcoming = OrderOutcoming,
                    status = OrderInCreation,
                    date = System.DateTime.Now
                };
                db.Orders.Add(order);
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
                    ViewBag.warehouse_name = new SelectList(db.Warehouses, "name", "name");
                    ViewBag.producer_name = new SelectList(db.Producers, "name", "name");
                    return View(ordersView);
                }
                return RedirectToAction("Details", new { id = order.id });
            }

            ViewBag.warehouse_name = new SelectList(db.Warehouses, "id", "name");
            ViewBag.producer_name = new SelectList(db.Producers, "id", "name");
            return View(ordersView);
        }

        // GET: OrdersViews/Edit/5
        public ActionResult Collect(int? id)
        {
            ViewBag.odView = (from x in db.OrderDetailsView where x.order_id == id select x).ToList();
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
        public ActionResult Collect([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            ViewBag.Exception = null;
            string msg = null;
            ViewBag.odView = (from x in db.OrderDetailsView where x.order_id == ordersView.id select x).ToList();
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = (from c in db.Orders where c.id == ordersView.id select c).First();
                    entity.status = OrderInRealization;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = "Invalid data";
                    else if (e.InnerException.InnerException == null)
                        msg = e.InnerException.Message;
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;
                    OrdersView ov = db.OrdersView.SingleOrDefault(m => m.id == ordersView.id);
                    return View(ov);
                }

                return RedirectToAction("Details", "OrdersViews", new { id = ordersView.id });
            }
            return View(ordersView);
        }










        // GET: OrdersViews/Edit/5
        public ActionResult Submit(int? id)
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
        public ActionResult Submit([Bind(Include = "id,warehouse_name,pub_name,producer_name,Incoming_Outcoming,status,date")] OrdersView ordersView)
        {
            ViewBag.Exception = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = (from c in db.Orders where c.id == ordersView.id select c).First();
                    entity.status = OrderInRealization;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                        msg = "Invalid data";
                    else if (e.InnerException.InnerException == null)
                        msg = e.InnerException.Message;
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;
                    OrdersView ov = db.OrdersView.SingleOrDefault(m => m.id == ordersView.id);
                    return View(ov);
                }

                return RedirectToAction("Details", "OrdersViews", new { id = ordersView.id });
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
            OrdersView ordersView = db.OrdersView.SingleOrDefault(m => m.id == id);
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
            ViewBag.Exception = null;
            string msg = null;
            OrdersView ordersView = db.OrdersView.SingleOrDefault(m => m.id == id);
            var entity = (from x in db.Orders where x.id == ordersView.id select x).First();

            db.Orders.Remove(entity);
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
                return View(ordersView);
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
