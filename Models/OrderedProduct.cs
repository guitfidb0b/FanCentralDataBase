
namespace FanCentral2.Models
{
    public class OrderedProduct
    {
        public int OrderedProductID { get; set; }
        public int Quanity { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}