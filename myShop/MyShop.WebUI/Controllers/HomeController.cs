using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> Context;
        IRepository<Productcategory> productcategories;

        public HomeController(IRepository<Product> productContext, IRepository<Productcategory> productCategoryContext)
        {
            Context = productContext;
            productcategories = productCategoryContext;
        }
        public ActionResult Index(string Category = null)
        {
            List<Product> Products;
            List<Productcategory> categories = productcategories.Collection().ToList();

            if(Category == null)
            {
                Products = Context.Collection().ToList();
            }
            else
            {
                Products = Context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = Products;
            model.Productcategories = categories;
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = Context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}