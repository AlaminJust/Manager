using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class AccountBalance
    {
        public int Id { get; set; }
        public double Taka { get; set; } 
        public string AddedBy { get; set; }
        public DateTime Date { get; set; } 
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual SubGroups SubGroups { get; set; } 
    }
}
