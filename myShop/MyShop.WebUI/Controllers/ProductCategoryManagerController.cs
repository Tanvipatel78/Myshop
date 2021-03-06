using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.DataAccess.inMemory;

namespace MyShop.WebUI.Controllers
{

    [Authorize(Roles = "Admin")]
    public class ProductCategoryManagerController : Controller
    {
        // GET: ProductCategory
        IRepository<Productcategory> Context;

        public ProductCategoryManagerController(IRepository<Productcategory> Context)
        {
            this.Context = Context;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Productcategory> productcategories = Context.Collection().ToList();
            return View(productcategories);
        }
        public ActionResult Create()
        {
            Productcategory productcategories = new Productcategory();
            return View(productcategories);
        }
        [HttpPost]
        public ActionResult create(Productcategory productcategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productcategory);
            }
            else
            {
                Context.Insert(productcategory);
                Context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(String Id)
        {
            Productcategory productcategory = Context.Find(Id);
            if (productcategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(Productcategory product, string Id)
        {
            Productcategory productcategoryToEdit = Context.Find(Id);
            if (productcategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productcategoryToEdit);
                }

                productcategoryToEdit.Category = product.Category;

                Context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            Productcategory productcategoryToDelete = Context.Find(Id);
            if (productcategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productcategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Productcategory productcategoryToDelete = Context.Find(id);
            if (productcategoryToDelete == null)
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
        public ActionResult GetGridCategory([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetOrderDetails().ToDataSourceResult(request));
        }
        private IEnumerable<Productcategory> GetOrderDetails()
        {
            List<Productcategory> data = Context.Collection().ToList();
            return data;
        }

    }
}
