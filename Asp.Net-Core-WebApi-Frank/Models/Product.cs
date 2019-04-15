using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Core_WebApi_Frank.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
