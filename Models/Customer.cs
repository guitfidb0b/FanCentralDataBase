using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanCentral2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }
    }
}