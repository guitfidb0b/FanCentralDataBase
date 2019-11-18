using System.Collections.Generic;

namespace FanCentral2.Models.ViewModels
{
    public class ProductIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}