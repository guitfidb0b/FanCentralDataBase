using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanCentral2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Image Name")]
        [StringLength(50)]
        public string ImageName { get; set; }
        [Required]
        [StringLength(50)]
        public decimal Price { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}