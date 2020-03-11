using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class MealDetails
    {
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; } 
        public int? Lunch { get; set; } 
        public int? Dinnar { get; set; } 
        public int? Morning { get; set; } 
        public virtual IdentityUser IdentityUser { get; set; } 
        public virtual SubGroups SubGroups { get; set; } 
    } 
} 