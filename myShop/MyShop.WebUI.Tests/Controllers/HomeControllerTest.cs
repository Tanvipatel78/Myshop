using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Myshop.core.Contracts;
using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using MyShop.WebUI;
using MyShop.WebUI.Controllers;

namespace MyShop.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository <Productcategory> productcategoryContext = new Mocks.MockContext<Productcategory>();

            productContext.Insert(new Product());
            HomeController controller = new HomeController(productContext, productcategoryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());
        }
    }
}
