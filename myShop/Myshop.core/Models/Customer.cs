using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.core.Models
{
    public class Customer : BaseEntity
    {
        public string UserId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName required")]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "LastName required")]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street required")]
        [StringLength(30)]
        public string Street { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "City required")]
        [StringLength(30)]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "State required")]
        [StringLength(30)]
        public string State { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ZipCode required")]
        [RegularExpression(@"^\d{6}(-\d{5})?$", ErrorMessage = "Invalid ZipCode")]
        public string ZipCode { get; set; }
    }
}
