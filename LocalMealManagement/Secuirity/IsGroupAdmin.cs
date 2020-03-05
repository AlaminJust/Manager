using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMealManagement.Secuirity
{
    public class IsGroupAdmin :
        AuthorizationHandler<ManageAdminRollAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRollAndClaimsRequirement requirement)
        {
            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if(authFilterContext == null)
            {
               // return Task.CompletedTask;
            }
            
            if(context.User.IsInRole("Admin") && 
                context.User.HasClaim(claim => claim.Type == "Create Role"))
            {
                context.Succeed(requirement);   
            }
            return Task.CompletedTask;

        }
    }
}
