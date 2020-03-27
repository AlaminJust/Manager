using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class UsersGroups
    {
        public int Id { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }
    }
}
