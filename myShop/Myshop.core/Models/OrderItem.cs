using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.core.Models
{
    public class OrderItem : BaseEntity
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductName required")]
        public string ProductName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is required")]
        [Range(0,1000)]
        public decimal price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        public static object Collection()
        {
            throw new NotImplementedException();
        }
    }
}
