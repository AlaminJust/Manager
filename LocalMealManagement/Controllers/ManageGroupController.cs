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
    public class ManageGroupController : Controller
    {
        private readonly IManageGroupRepository manageGroupRepository;
        private readonly ISubGroupRepository subGroupRepository;
        public ManageGroupController(IManageGroupRepository manageGroupRepository , ISubGroupRepository subGroupRepository)
        {
            this.manageGroupRepository = manageGroupRepository;
            this.subGroupRepository = subGroupRepository;
        }
        [HttpGet]
        [Authorize(Policy = "SuparAdmin")]
        public IActionResult AddMemberInGroup(string groupId)
        {
            ViewBag.groupId = groupId;
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "SuparAdmin")]
        public async Task<IActionResult> AddMemberInGroup(string groupId , UserNameViewModel model)
        {
            ViewBag.groupId = groupId;
            if (ModelState.IsValid)
            {
                var result = await manageGroupRepository.AddMemberInGroup(groupId, model.UserName);
                if(result == "Memeber Added")
                {
                    return RedirectToAction("AllGroups", "GroupAdministration");
                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Policy = "SuparAdmin")]
        public IActionResult MembersInGroup(string groupId, string subGroupId="NULL")
        {
            ViewBag.groupId = groupId;
            ViewBag.subGroupId = subGroupId;
            var users = manageGroupRepository.UsersInGroup(groupId,subGroupId);
            return View(users);
        }
        [HttpGet]
        [Authorize(Policy = "SuparAdmin")]
        public async Task<IActionResult> KickOutUserFromGroup(string userId , int? groupId)
        {
            if(userId == null || groupId == null)
            {
                return BadRequest();
            }
            if (await manageGroupRepository.KickOutUser(userId, groupId))
            {
                return RedirectToAction("MembersInGroup" , new { groupId = groupId});
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult CostList(string groupId , string subGroupId)
        {
            var costList = subGroupRepository.CostList(subGroupId);
            return View(costList); 
        }
        [HttpGet]
        public IActionResult AllCalculation(string groupId , string subGroupId)
        {
            var allCalculation = subGroupRepository.allCalculations(subGroupId);
            return View(allCalculation);
        }

    }
}