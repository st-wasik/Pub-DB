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

        // GET: OrderDetailsViews/Create
        public ActionResult CreateForProduct()
        {
            if (RouteData.Values["id"] == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ViewBag.order_id = RouteData.Values["id"];
            int orderID = int.Parse(ViewBag.order_id);

            var In_Out = (from o in db.Orders where o.id == orderID select o.Incoming_Outcoming).First();
            ViewBag.In_Out = In_Out;
            if (In_Out.Equals("Incoming"))
            {
                ViewBag.product_name = new SelectList((from p in db.Products
                                                       join s in db.WarehousesStock on p.id equals s.product_id
                                                       join w in db.Warehouses on s.warehouse_id equals w.id
                                                       join o in db.Orders on w.id equals o.warehouse_id
                                                       where o.id == orderID
                                                       select p.name).ToList());
            }
            else
            {
               // ViewBag.product_name = new SelectList(db.Products, "name", "name");

                ViewBag.product_name = new SelectList((from p in db.Products
                                                       join pr in db.Producers on p.producer_id equals pr.id
                                                       join o in db.Orders on pr.id equals o.producer_id
                                                       where o.id == orderID
                                                       select p.name).ToList());
            }

            return View();
        }

        // POST: OrderDetailsViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateForProduct([Bind(Include = "id,order_id,quantity,product_name")] OrderDetailsView orderDetailsView)
        {
            ViewBag.Exception = null;
            string msg = "";
            if (ModelState.IsValid)
            {
                var order_id = orderDetailsView.order_id;
                var p_name = orderDetailsView.product_name;

                OrderDetails od = new OrderDetails
                {
                    order_id = orderDetailsView.order_id,
                    quantity = orderDetailsView.quantity,
                    product_id = (from p in db.Products where p.name == p_name select p).First().id
                };
                db.OrderDetails.Add(od);
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
                    ViewBag.order_id = RouteData.Values["id"];

                    ViewBag.product_name = new SelectList(db.Products, "name", "name");

                    return View(orderDetailsView);
                }
                return RedirectToAction("Details", "OrdersViews", new { id = order_id });
            }
            ViewBag.order_id = RouteData.Values["id"];

            ViewBag.product_name = new SelectList(db.Products, "name", "name");
            return View(orderDetailsView);
        }

        // GET: OrdersViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsView ordersView = db.OrderDetailsView.SingleOrDefault(m => m.id == id);
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
            OrderDetailsView odv = db.OrderDetailsView.SingleOrDefault(m => m.id == id);
            var entity = (from x in db.OrderDetails where x.id == odv.id select x).First();
            var orderid = entity.order_id;
            db.OrderDetails.Remove(entity);
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

                ViewBag.order_id = odv.order_id;
                ViewBag.Exception = msg;
                return View(odv);
            }

            return RedirectToAction("Details", "OrdersViews", new { id = orderid });
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
