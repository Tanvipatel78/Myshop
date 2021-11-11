using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class MyOrderController : Controller
    {
        // GET: MyOrder
        public ActionResult MyorderDetails()
        {
            return View();
        }
    }
}