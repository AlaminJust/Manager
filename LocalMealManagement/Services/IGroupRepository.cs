using LocalMealManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Services
{
    public interface IGroupRepository
    {
        public Task<Boolean> CreateGroup(string groupName);
        public Task<Boolean> AddMember(string userName , string groupId);
        public Task<Boolean> AssignUserInRole(string userName , string RoleName);
        public string GetGroupId(string groupName);
        public Task<List<Groups>> AllGroupOfUser(string UserName);
        public Task<Boolean> save();
    }
}
