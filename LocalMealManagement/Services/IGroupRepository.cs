using LocalMealManagement.Models;
using LocalMealManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public interface IGroupRepository
    {
        public Task<Boolean> CreateGroup(string groupName);
        public Task<Boolean> AssignUserInRole(string userName , string RoleName);
        public Task<Boolean> AssignUserInGroupRole(string userName, string RoleName, string groupId);
        public string GetGroupId(string groupName);
        public Task<List<Groups>> AllGroupOfUser(string UserName);
        public List<SubGroupViewModel> AllSubGroupsInAGroup(string groupId); 
        public Task<Boolean> save();
        
    }
}
