using Myshop.core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketservice;

        public BasketController(IBasketService BasketService)
        {
            this.basketservice = BasketService;
        }
        // GET: Basket
        public ActionResult Index()
        {

            return View();
        }
    }
}