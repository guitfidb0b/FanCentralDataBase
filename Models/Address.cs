using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FanCentral2.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        [StringLength(50)]
        public string StreetAddress { get; set; }
        [Required]
        [StringLength(25)]
        public string City { get; set; }
        [Required]
        [StringLength(25)]
        public string State { get; set; }
        [Required]
        //[DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }
        public Customer Customer { get; set; }
    }
}