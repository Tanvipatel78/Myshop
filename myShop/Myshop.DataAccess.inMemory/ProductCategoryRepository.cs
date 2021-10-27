using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Myshop.Core;
using Myshop.core.Models;

namespace Myshop.DataAccess.inMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Productcategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<Productcategory>;
            if (productCategories == null)
            {
                productCategories = new List<Productcategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(Productcategory p)
        {
            productCategories.Add(p);
        }

        public void Update(Productcategory productcategory)
        {
            Productcategory productcategoryToUpdate = productCategories.Find(p => p.Id == productcategory.Id);

            if (productcategoryToUpdate != null)
            {
                productcategoryToUpdate = productcategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }
        public Productcategory Find(string Id)
        {
            Productcategory productcategory = productCategories.Find(p => p.Id == Id);

            if (productcategory != null)
            {
                return productcategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }

        }
        public IQueryable<Productcategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            Productcategory productcategoryToDelete = productCategories.Find(p => p.Id == Id);

            if (productcategoryToDelete != null)
            {
                productCategories.Remove(productcategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
