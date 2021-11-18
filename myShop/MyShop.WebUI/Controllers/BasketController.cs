using Microsoft.AspNet.Identity;
using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IRepository<Customer> Customers;
        IBasketService basketService;
        IOrderService orderService;
        private object shop;

        public BasketController(IBasketService BasketService, IOrderService OrderService, IRepository<Customer> Customers)
        {
            this.basketService = BasketService;
            this.orderService = OrderService;
            this.Customers = Customers;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketService.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);
            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
        [Authorize]
        public ActionResult CheckOut()
        {
            Customer customer = Customers.Collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            if (customer != null)
            {
                Order order = new Order()
                {
                    Email = customer.Email,
                    City = customer.City,
                    State = customer.State,
                    Street = customer.Street,
                    FirstName = customer.FirstName,
                    SurName = customer.LastName,
                    ZipCode = customer.ZipCode
                };

                //order.BasketItems = basketService.GetBasketItemsDb(id);
                return View(order);
            }
            else
            {
                return View(new Order());
                //return RedirectToAction("Error");
            }
        }
        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(Order order)
        {
            var basketItems = basketService.GetBasketItems(this.HttpContext);
            order.OrderStatus = "Order Created";
            order.Email = User.Identity.Name;

            //Process payment
            order.OrderStatus = "payment Processed";
            orderService.CreateOrder(order, basketItems);
            basketService.ClearBasket(this.HttpContext);
            return RedirectToAction("ThankYou", new { OrderId = order.Id });
        }

        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }
        public ActionResult Error(string OrderId)
        {
            //ViewBag.OrderId = OrderId;
            return View();
        }
        //[HttpPost]
        //public ActionResult UpdateCartPrice(FormCollection Fc)
        //{
        //    string quantities = Fc.GetValues("quantity").FirstOrDefault();
        //    string product_id = Fc.GetValues("product_id").FirstOrDefault();
        //    List<BasketItem> cart = List<BasketItem>.Where(Model => Model.Price(from p in Model select p.Price * p.quantities)) and ( Model=>Model.Basket Total(from q in Model select q.Price * q.quantities)Sum();
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        cart[i].Quantity = Convert.ToInt32(quantities[i]); 
        //    }
        //    return View("Success");
        //}
        public ActionResult GetBasketItems()
        {
            List<BasketItemViewModel> basket = basketService.GetBasketItems(this.HttpContext);
            return View(basket);
        }
    }
}
