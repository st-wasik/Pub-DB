using System;
using System.Linq;
using System.Web.Mvc;

using Mongo.Models;
using PubDBApplication.Models;

namespace Mongo.Controllers
{
    public class OrdersArchiveController : Controller
    {
        private MongoAccess mongo = new MongoAccess();
        private PubDBEntities db = new PubDBEntities();

        // GET: OrdersArchive
        public ActionResult Index()
        {
            ViewBag.archiveContent = mongo.GetOrders().ToList();
            return View();
        }

        public ActionResult Archive(int id)
        {
            ViewBag.toArchive = (from x in db.OrdersView where x.id == id select x).First();
            ViewBag.products = (from x in db.OrderDetailsView where x.order_id == id select x).ToList();
            return View();
        }

        [HttpPost, ActionName("Archive")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int id)
        {
            ViewBag.toArchive = (from x in db.OrdersView select x).First();
            ViewBag.products = (from x in db.OrderDetailsView where x.order_id == id select x).ToList();

            ViewBag.Exception = null;
            string msg = null;

            var ord = (from x in db.Orders where x.id == id select x).First();

            if (!ord.status.Equals("Completed"))
            {
                ViewBag.Exception = "Only completed orders can be archived.";
                return View(id);
            }

            var orderView = (from x in db.OrdersView where x.id == id select x).First();

            var details = (from x in db.OrderDetailsView where x.order_id == id select x).ToList();

            Mongo.Models.Order orderToArchive = new Mongo.Models.Order();

            orderToArchive.OrderID = orderView.id;
            orderToArchive.From = (orderView.pub_name != null ? orderView.pub_name : orderView.warehouse_name);
            orderToArchive.To = (orderView.producer_name != null ? orderView.producer_name : orderView.warehouse_name);
            orderToArchive.Date = orderView.date.ToString();
            orderToArchive.TotalPrice = orderView.total.ToString("0.00");

            foreach (var p in details)
            {
                orderToArchive.ProductsInfo += p.toMongoString() + ";\n";
            }

           db.Orders.Remove(ord);

            try
            {
                db.SaveChanges();
                mongo.Create(orderToArchive);
            }
            catch (Exception e)
            {
                if (e.InnerException == null)
                    msg = e.Message;
                else
                    msg = e.InnerException.InnerException.Message;

                ViewBag.Exception = msg;
                return View(id);
            }
            return RedirectToAction("Index");
        }
    }
}