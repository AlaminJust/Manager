using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalMealManagement.Services;
using LocalMealManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalMealManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IGroupRepository groupRepository;
        public UsersController(UserManager<IdentityUser> userManager,
                               SignInManager<IdentityUser> signInManager, IGroupRepository groupRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.groupRepository = groupRepository;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, PasswordHash = model.Password , PhoneNumber = model.PhoneNumber };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.Name != null)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signedUser = await userManager.FindByEmailAsync(model.Email);
                var result = await signInManager.PasswordSignInAsync(signedUser.UserName, model.Password, true, false);
                if (result.Succeeded)
                {
                    return Json(new { result = "Redirect", url = Url.Action("index", "home") });
                }
                else
                {
                    return BadRequest();
                }
            }
            return View(model);
        }
    }
}