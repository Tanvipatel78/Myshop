using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using Myshop.DataAccess.inMemory;
using Myshop.core.Models;
using Myshop.core.Contracts;
using System.IO;

namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> Context;
        IRepository<Productcategory> productcategories;

        public ProductManagerController(IRepository<Product> productContext , IRepository<Productcategory> productCategoryContext)
        {
            Context = productContext;
            productcategories = productCategoryContext;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = Context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {

            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.product = new Product();
            viewModel.productcateories = productcategories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult create(Product product , HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                if(file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Productimages//") + product.Image);
                }
                Context.Insert(product);
                Context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(String Id)
        {
            Product product = Context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = product;
                viewModel.productcateories = productcategories.Collection();

                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product , string Id , HttpPostedFileBase file)
        {
            Product productToEdit = Context.Find(Id);
            if(productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }

                if(file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Productimages//") + product.Image);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                Context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = Context.Find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Product productToDelete = Context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                Context.Delete(id);
                Context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}