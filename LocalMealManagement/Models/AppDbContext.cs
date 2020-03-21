using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Groups> groups { get; set; } 
        public DbSet<UsersGroups> usersGroups { get; set; } 
        public DbSet<MealDetails> mealDetails { get; set; } 
        public DbSet<SubGroups> subGroups { get; set; }  
        public DbSet<AccountBalance> accountBalance { get; set; }  
        public DbSet<CostTable> costTables { get; set; }   
    }
}
