using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.core.Models
{
    public class Productcategory
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public Productcategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
