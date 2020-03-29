using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password" , ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression("(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\\d{8})$", ErrorMessage = "Does'nt match!")]
        public string PhoneNumber { get; set; }
    }
}
