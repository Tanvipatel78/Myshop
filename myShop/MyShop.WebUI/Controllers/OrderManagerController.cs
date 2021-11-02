using Myshop.core.Contracts;
using Myshop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class OrderManagerController : Controller
    {
        IOrderService OrderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }
        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> Orders = OrderService.GetOrderList();
            return View(Orders);
        }
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.statusList = new List<string>()
            {
                "Order Created",
                "Payment processed",
                "Order Shipped",
                "Order Complete"
        };
            Order Order = OrderService.GetOrder(Id);
            return View(Order);
        }
        public ActionResult UpdateOrder(Order updateOrder , string Id)
        {
            Order order = OrderService.GetOrder(Id);
            order.OrderStatus = updateOrder.OrderStatus;
            OrderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}