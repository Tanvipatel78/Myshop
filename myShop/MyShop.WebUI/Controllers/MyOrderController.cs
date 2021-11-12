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
        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> Orders = orderService.GetOrderList();
            return View(Orders);
        }
    }
}