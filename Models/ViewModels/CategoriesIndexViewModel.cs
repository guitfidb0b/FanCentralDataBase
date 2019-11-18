using System.Collections.Generic;

namespace FanCentral2.Models.ViewModels
{
    public class CategoriesIndexViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}