using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Ajax.Utilities;
using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService orderService;

        public OrderManagerController(IOrderService OrderService)
        {
            this.orderService = OrderService;
        }
        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> Orders = orderService.GetOrderList();
            return View(Orders);
        }
        public ActionResult UpdateOrder(string Id)
        {
            ViewBag.StatusList = new List<string>()
            {
                "Order Created",
                "Payment processed",
                "Order Shipped",
                "Order Complete"
        };
            Order Order = orderService.GetOrder(Id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult UpdateOrder(Order updateOrder , string Id)
        {
            Order order = orderService.GetOrder(Id);
            order.OrderStatus = updateOrder.OrderStatus;
            orderService.UpdateOrder(order);

            return RedirectToAction("Index");
        }
        public ActionResult GetGridOrderData([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetOrderDetails().ToDataSourceResult(request));
        }
        private IEnumerable<Order> GetOrderDetails()
        {
            List<Order> data = orderService.GetOrderList();
            return data;
        }

    }
}