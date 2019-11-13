using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanCentral2.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}