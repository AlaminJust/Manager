using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class SubGroups 
    {
        public int Id { get; set; }
        public string SubGroupName { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
