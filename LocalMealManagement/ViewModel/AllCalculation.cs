using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.ViewModel
{
    public class AllCalculation
    {
        public double Morning { get; set; }
        public double Dinnar { get; set; }
        public double Lunch { get; set; }
        public double Taka { get; set; }
        public double TotalCost { get; set; }
        public IdentityUser identityUser { get; set; } 
    }
}
