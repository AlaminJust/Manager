using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password" , ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; } 
    }
}
