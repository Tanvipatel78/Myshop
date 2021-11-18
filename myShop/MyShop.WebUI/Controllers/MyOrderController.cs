using Microsoft.AspNet.Identity;
using Myshop.core.Contracts;
using Myshop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class MyOrderController : Controller
    {
        IOrderService orderService;

        public MyOrderController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        [Authorize]
        //GET: OrderManager
        public ActionResult Index()
        {

            List<Order> Orders = orderService.GetOrderList().Where(p => p.Email == User.Identity.GetUserName()).ToList();
            return View(Orders);
        }
        [Authorize]
        public ActionResult GetOrderdetails()
        {

            List<Order> Orders = orderService.GetOrderList().Where(p => p.Email == User.Identity.GetUserName()).ToList();
            return View(Orders);
        }
    }
}