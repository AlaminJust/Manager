﻿using System;
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
        private readonly ISubGroupRepository subGroupRepository;
        private readonly int[] NumberOfDayInMonth = {0 , 31 , 28, 31, 30, 31 , 30 , 31 , 31 , 30 , 31 , 30 , 31}; 
        public GroupAdministrationController(AppDbContext context , UserManager<IdentityUser>userManager,
            IGroupRepository groupRepository, ISubGroupRepository subGroupRepository)
        {
            this.context = context;
            this.userManager = userManager;
            this.groupRepository = groupRepository;
            this.subGroupRepository = subGroupRepository;
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
        public async Task<IActionResult>AllGroups()
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
            ViewBag.groupId = groupId;
            var subgroups = groupRepository.AllSubGroupsInAGroup(groupId);
            return View(subgroups);
        }

        /// Create Subgroup
        [HttpGet]
        public IActionResult CreateSubGroup(string groupId)
        {
            ViewBag.groupId = groupId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubGroup(CreateSubgroupViewModel model , string groupId)
        {
            ViewBag.groupId = groupId;
            if (ModelState.IsValid)
            {
                string userName = User.Identity.Name;
                await subGroupRepository.AddSubGroup(userName, groupId, model);
                return RedirectToAction("SpecificGroupTask", new { groupId });
            }
            ModelState.AddModelError("", "Something going wrong");
            return View(model);
        }


        // Generate Day Formate for giving and updating meal in the subgroups
        [HttpGet]
        public IActionResult MealsFormate(string subGroupId , string groupId) 
        {
            ViewBag.groupId = groupId;
            DateTime now = DateTime.Now; 
            int month = now.Month; 
            int day = NumberOfDayInMonth[month]; 
            DateTime StartDay = new DateTime(now.Year, month, 1); 
            List<SubGroupMonthlyViewModel> subGroupMonthlyViewModels = new List<SubGroupMonthlyViewModel>(); 
            for(int i = 1; i<=day; i++) 
            { 
                SubGroupMonthlyViewModel subGroup = new SubGroupMonthlyViewModel() 
                { 
                    CurrentDay = StartDay, 
                    SubGroupId = subGroupId 
                }; 
                subGroupMonthlyViewModels.Add(subGroup);
                StartDay = StartDay.AddDays(1);
            } 
            return View(subGroupMonthlyViewModels); 
        }
        
        [HttpGet]
        public IActionResult AddMeals(string groupId , string subGroupId , DateTime date)
        {
            ViewBag.groupId = groupId;
            ViewBag.subGroupId = subGroupId;
            ViewBag.dateTime = date;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeals(MealModelView model , string groupId , string subGroupId, DateTime date )
        {
            ViewBag.groupId = groupId;
            ViewBag.subGroupId = subGroupId;
            ViewBag.dateTime = date;
            if (ModelState.IsValid)
            {
                if(await subGroupRepository.AddMeal(model, subGroupId, User.Identity.Name , date)) /// Meal Added Successfull
                {
                    ViewBag.Success = "Meal Added Successfully";
                    return RedirectToAction("MealsFormate", new { groupId = groupId , subGroupId = subGroupId});
                }
                else
                {
                    ModelState.AddModelError("", "Somethings Going Wrong");
                }
            }
            return View(model);
        }

        // Update Meal 
        // Group Id need for authorzation
        [HttpGet]
        public IActionResult UpdateMeals(string groupId, string subGroupId, DateTime date)
        {
            ViewBag.groupId = groupId;
            ViewBag.subGroupId = subGroupId;
            ViewBag.dateTime = date;
            MealModelView mealModelView = subGroupRepository.ShowMeal(subGroupId, User.Identity.Name, date);
            return View(mealModelView);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMeals(MealModelView model, string groupId , string subGroupId , DateTime date)
        {
            ViewBag.groupId = groupId;
            ViewBag.subGroupId = subGroupId;
            ViewBag.dateTime = date;
            if (ModelState.IsValid)
            {
                if (await subGroupRepository.UpdateMeal(model, subGroupId, User.Identity.Name, date))
                {
                    // Updated Succesfully
                    return RedirectToAction("MealsFormate", new { groupId = groupId, subGroupId = subGroupId });
                }
                else
                {
                    ModelState.AddModelError("", "Somethings going Wrong");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ShowMeal(string groupId , string subGroupId , DateTime date)
        {
            MealModelView mealDetails = subGroupRepository.ShowMeal(subGroupId, User.Identity.Name, date);
            if(mealDetails == null) // You do not give meal yeat
            {
                mealDetails = new MealModelView()
                {
                    Dinnar = 0,
                    Lunch = 0,
                    Morning = 0
                };
            }
            return View(mealDetails);
        }

        // To show specific subgroups All users meals
        [HttpGet]
        public IActionResult SubGroupsAllUsersMeals(string groupId , string subGroupId , DateTime date)
        {
            var subGroupAllUserMeals = subGroupRepository.SubGroupAllUserMeals(subGroupId, date);
            return View(subGroupAllUserMeals);
        }

    } 
} 