using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FanCentral2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter Product Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Image Name")]
        [Display(Name = "Image Name")]
        [StringLength(50)]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a Positive Price")]
        public decimal Price { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}