using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FanCentral2.Models;

namespace FanCentralDataBase.Models.ViewModels
{
    public class BrowseProductCategories
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}