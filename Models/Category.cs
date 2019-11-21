using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanCentral2.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string CategoryCategory { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}