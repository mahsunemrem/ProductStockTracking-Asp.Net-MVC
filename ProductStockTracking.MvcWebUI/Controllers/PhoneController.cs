using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStockTracking.MvcWebUI.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PhoneList()
        {
            return View();
        }

        public ActionResult AddPhone()
        {
            return View();
        }
    }
}