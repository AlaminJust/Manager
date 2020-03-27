using LocalMealManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LocalMealManagement.Secuirity
{
    public class IsGroupAdmin : AuthorizationHandler<ManageAdminRollAndClaimsRequirement>
    {
        private readonly AppDbContext appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IsGroupAdmin(AppDbContext appDbContext, IHttpContextAccessor _httpContextAccessor) 
        {
            this.appDbContext = appDbContext;
            this._httpContextAccessor = _httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRollAndClaimsRequirement requirement)
        {
            var authFilterContext = _httpContextAccessor.HttpContext.Request;
            if (authFilterContext == null)
            {
                return Task.CompletedTask;
            }
            string ID = authFilterContext.Query["groupId"].ToString();
            var currentUser = _httpContextAccessor.HttpContext.User.Identity.Name;

            var res = appDbContext.usersGroups.Where(x => x.Groups.GroupId.ToString() == ID && x.IdentityUser.UserName == currentUser && x.IdentityRole.Name == "Admin").FirstOrDefault();
            if (currentUser == null || res == null)
            {
                return Task.CompletedTask;
            }
            else
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}





//} for version below 3.00
//protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
//                        ManageAdminRollAndClaimsRequirement requirement)
//{
//    var authFilterContext = context.Resource as AuthorizationFilterContext;
//    if (authFilterContext == null)
//    {
//        return Task.CompletedTask;
//    }
//    var request = authFilterContext.HttpContext.Request;
//    var currentUser = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
//    string ID = request.Query["groupId"].ToString();
//    var res = appDbContext.usersGroups.Where(x => x.Groups.GroupId.ToString() == ID && x.IdentityUser.UserName == currentUser).FirstOrDefault();
//    if (context.User.IsInRole("Admin") && context.User.IsInRole("SuparAdmin") && res != null)
//    {
//        context.Succeed(requirement);
//    }
//    return Task.CompletedTask;

//}