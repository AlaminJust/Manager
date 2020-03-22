using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class MealModelView 
    { 
        public int? Lunch { get; set; } 
        [Required] 
        public int? Dinnar { get; set; } 
        [Required] 
        public int? Morning { get; set; } 
    } 

    public class MealModelWithUserNameView : MealModelView
    {
        public IdentityUser IdentityUser { get; set; }  
    }
}
