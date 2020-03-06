﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalMealManagement.ViewModel; 

namespace LocalMealManagement.Services
{
    public interface IManageGroupRepository
    { 
        public Task<string> AddMemberInGroup(string groupId, string userName);
        public List<UserViewModel> UsersInGroup(string groupId);
    }
}
