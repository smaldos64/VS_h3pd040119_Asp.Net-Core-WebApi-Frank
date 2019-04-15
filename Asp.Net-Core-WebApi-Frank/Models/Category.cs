using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Core_WebApi_Frank.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
