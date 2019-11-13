using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanCentral2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Shipped?")]
        public bool IsShipped { get; set; }
        [Display(Name = "Shipping Date")]
        [DataType(DataType.DateTime)]
        public DateTime ShippingDate { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}