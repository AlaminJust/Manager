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

        public List<UserViewModel> UsersInGroup(string groupId) 
        {
            var result = (from ug in context.usersGroups
                          where (ug.Groups.GroupId.ToString() == groupId)
                          select new UserViewModel
                          {
                              UserId = ug.IdentityUser.Id,
                              UserName = ug.IdentityUser.UserName
                          }).ToList();
            return result;
        }
    }
}
