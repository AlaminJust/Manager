using LocalMealManagement.Models;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountRepository(AppDbContext Context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            context = Context;
            this.userManager = userManager; 
            this.signInManager = signInManager;
        }

        public async Task<Boolean> AddBalance(AccountViewModel model, string AddedBy)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            var subGroups = context.subGroups.Where(x => x.Id.ToString() == model.subGroupId).FirstOrDefault();
            if (user == null || subGroups == null) return false;

            AccountBalance account = new AccountBalance()
            {
                Taka = model.Taka,
                AddedBy = AddedBy,
                Date = DateTime.UtcNow,
                IdentityUser = user,
                SubGroups = subGroups
            };
            await context.accountBalance.AddAsync(account);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
