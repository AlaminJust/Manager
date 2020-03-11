using LocalMealManagement.Models;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public class SubGroupRepository : ISubGroupRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public SubGroupRepository(AppDbContext Context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            context = Context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> AddMeal(MealModelView model, string subGroupId, string userName , DateTime date)
        {
            var user = await userManager.FindByNameAsync(userName);
            var subGroup = context.subGroups.Where(x => x.Id.ToString() == subGroupId).FirstOrDefault();
            if(user == null || subGroup == null)
            {
                return false;
            }
            MealDetails mealDetails = new MealDetails
            {
                IdentityUser = user,
                SubGroups = subGroup,
                Dinnar = model.Dinnar,
                Lunch = model.Lunch,
                Morning = model.Morning,
                OrderDate = date
            };
            context.mealDetails.Add(mealDetails);
            return await Save();
        }

        public async Task<bool> UpdateMeal(MealModelView model, string subGroupId, string userName, DateTime date)
        {
            var mealDetailsUpdate = context.mealDetails.Where(x => x.SubGroups.Id.ToString() == subGroupId && x.IdentityUser.UserName == userName && x.OrderDate == date).FirstOrDefault();
            mealDetailsUpdate.Lunch = model.Lunch;
            mealDetailsUpdate.Morning = model.Morning;
            mealDetailsUpdate.Dinnar = model.Dinnar;
            return await Save();
        }

        public MealModelView ShowMeal(string subGroupId, string userName, DateTime date)
        {
            var mealDetailsShow = context.mealDetails.Where(x => x.SubGroups.Id.ToString() == subGroupId && x.IdentityUser.UserName == userName && x.OrderDate == date).FirstOrDefault();
            if(mealDetailsShow == null)
            {
                return null;
            }
            MealModelView mealModelView = new MealModelView
            {
                Morning = mealDetailsShow.Morning,
                Dinnar = mealDetailsShow.Dinnar,
                Lunch = mealDetailsShow.Lunch
            };
            return mealModelView;
        }

        public async Task<bool> AddSubGroup(string userName , string groupId, CreateSubgroupViewModel model)
        {
            var groups = context.groups.Where(x => x.GroupId.ToString() == groupId).FirstOrDefault();
            var user = await userManager.FindByNameAsync(userName);
            SubGroups subGroups = new SubGroups
            {
                SubGroupName = model.SubGroupName,
                CreateDate = DateTime.Now,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Groups = groups,
                IdentityUser = user
            };
            context.subGroups.Add(subGroups);
            return await Save();
        }
        public List<MealModelWithUserNameView> SubGroupAllUserMeals(string subGroupId, DateTime date)
        {
            var AllUsersMealInSubGroup = (from m in context.mealDetails
                                          join sg in context.subGroups on m.SubGroups.Id equals sg.Id
                                          where (sg.Id.ToString() == subGroupId && m.OrderDate == date)
                                          select new MealModelWithUserNameView
                                          {
                                              Dinnar = m.Dinnar,
                                              Lunch = m.Lunch,
                                              Morning = m.Morning,
                                              UserName = m.IdentityUser.UserName
                                          }).ToList();
                       
            return AllUsersMealInSubGroup;
        }
        public async Task<bool> Save()
        {
            await context.SaveChangesAsync();
            return true;
        }

        
    }
}
