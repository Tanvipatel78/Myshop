using Myshop.core.Models;
using Myshop.core.ViewModels;
using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyshopDataccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
            {

            }
        public DbSet<Product> Products { get; set; }
        public DbSet<Productcategory> Productcategories { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<MyOrderDetails> MyOrderDetails { get; set; }



    }
}
