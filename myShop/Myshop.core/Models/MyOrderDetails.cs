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
        public string ProductName { get; set; }
        [Range(0, 1000)]
        public decimal price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public String OrderStatus { get; set; }

        public MyOrderDetails()
        {
            //this.OrderStatus = new List<OrderItem>();
        }
    }
}
