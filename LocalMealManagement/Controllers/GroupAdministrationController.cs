using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalMealManagement.Models;
using LocalMealManagement.Services;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalMealManagement.Controllers
{
    public class GroupAdministrationController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IGroupRepository groupRepository;
        public GroupAdministrationController(AppDbContext context , UserManager<IdentityUser>userManager,
            IGroupRepository groupRepository)
        {
            this.context = context;
            this.userManager = userManager;
            this.groupRepository = groupRepository;
        }
        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var userName = User.Identity.Name;
                if(!(await groupRepository.CreateGroup(model.GroupName)))
                {
                    ModelState.AddModelError("", "Group name already exist");
                    return View(model);
                }
                string currentGroupId = groupRepository.GetGroupId(model.GroupName);
                await groupRepository.AddMember(userName, currentGroupId);
                await groupRepository.AssignUserInRole(userName, "SuparAdmin");
            }
            return RedirectToAction("AllGroups");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllGroups()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name); 
            if(user == null)
            {
                return Ok("User is not valid");
            }
            else
            {
                var groups = await groupRepository.AllGroupOfUser(user.UserName);
                return View(groups);
            }
        }
        [Authorize(Policy = "SuparAdmin")]
        public IActionResult SpecificGroupTask(string groupId)
        {
            return Ok("I Am Really Happy To See This Value");
        }

    }
}