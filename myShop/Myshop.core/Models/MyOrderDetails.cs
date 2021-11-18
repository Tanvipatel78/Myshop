using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.core.Models
{
    public class MyOrderDetails : BaseEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ProductName { get; set; }
        [Range(0, 1000)]
        public decimal price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public IList<BasketItem> BasketItems { get; set; }

        public MyOrderDetails()
        {
            //this.OrderStatus = new List<OrderItem>();
        }
    }
}
