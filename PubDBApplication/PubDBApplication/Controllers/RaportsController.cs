using PubDBApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PubDBApplication.Controllers
{
    public class RaportsController : Controller
    {
        private PubDBEntities db = new PubDBEntities();

        // GET: Raports/Details/5
        public ActionResult Details(int id = 0)
        {
            ViewBag.RaportType = id;
            return View();
        }
    }
}
