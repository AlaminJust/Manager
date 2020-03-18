using LocalMealManagement.Models;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public class ManageGroupRepository : IManageGroupRepository
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDbContext context;
        private readonly IGroupRepository groupRepository;
        public ManageGroupRepository(UserManager<IdentityUser> userManager, AppDbContext context,
                     IGroupRepository groupRepository, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.groupRepository = groupRepository;
            this.context = context;

        }
        public async Task<string> AddMemberInGroup(string groupId, string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            string result = "Memeber Added";
            if (user == null)
            {
                result = "Username is not valid";
                return result;
            }
            var group = context.groups.Where(x => x.GroupId.ToString() == groupId).FirstOrDefault();
            if (group == null)
            {
                result = "Groupname is invalid!";
                return result;
            }
            if (!(await groupRepository.AddMember(userName, groupId)))
            {
                result = "Somethings went wrong check it carefully!";
                return result;
            }
            return result;
        }

        public async Task<bool> KickOutUser(string userId, int? groupId)
        {
            if(userId == null || groupId == null)
            {
                return false;
            }
            var groupUsers = context.usersGroups.Where(x => x.IdentityUser.Id == userId && x.Groups.GroupId == groupId)
                             .FirstOrDefault();

            if(groupUsers == null)
            {
                return false;
            }
            context.usersGroups.Remove(groupUsers);
            await Save();
            return true;
        }

        public async Task<bool> Save()
        {
            await context.SaveChangesAsync();
            return true;
        }

        public List<UserViewModel> UsersInGroup(string groupId , string subGroupId) 
        {
            var result = (from ug in context.usersGroups
                          where (ug.Groups.GroupId.ToString() == groupId)
                          select new UserViewModel
                          {
                              UserId = ug.IdentityUser.Id,
                              UserName = ug.IdentityUser.UserName,
                              subGroupId = subGroupId
                          }).ToList();
            return result;
        }
    }
}
