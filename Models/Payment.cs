using System;
using System.ComponentModel.DataAnnotations;

namespace FanCentral2.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        [StringLength(16)]
        //[DataType(DataType.CreditCard)]
        public long CardNumber { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        [StringLength(5)]
        public DateTime Expiration { get; set; }
        [Required]
        [Display(Name = "Name On Card")]
        [StringLength(50)]
        public string NameOnCard { get; set; }
        [Required]
        [StringLength(4)]
        public int Code { get; set; }
        public Customer Customer { get; set; }
    }
}