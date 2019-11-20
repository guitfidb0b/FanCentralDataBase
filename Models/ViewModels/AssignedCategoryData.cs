using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanCentral2.Models.ViewModels
{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Assigned { get; set; }
    }
}