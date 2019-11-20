using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ThreadingTasks;

namespace FanCentral2.Models.LoginViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress {get; set;}

        [Required]
        [Datatype(Datatype.password)]
        public string password {get; set;}

        [Display(Name = "Remember me")]
        public bool RememberMe {get; set;}

    }
    
}