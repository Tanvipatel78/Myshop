using Myshop.core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{
    public class Product : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "ProductName required")]
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }
        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
