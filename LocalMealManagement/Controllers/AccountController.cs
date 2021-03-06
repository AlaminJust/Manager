﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalMealManagement.Services;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalMealManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBalance(string groupId , AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                string AddedBy = User.Identity.Name;
                if (await accountRepository.AddBalance(model, AddedBy))
                {
                    return Json( model );
                }
            }
            ModelState.AddModelError("", "Something Going Wrong");
            return View(model);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}