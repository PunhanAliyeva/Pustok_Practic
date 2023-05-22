using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController:Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegisterVM newuser)
        {
            if(!ModelState.IsValid) return View();
            AppUser appUser = new AppUser
            {
                Name = newuser.Name,
                Surname = newuser.Surname,
                Email = newuser.Email,
                UserName = newuser.Username
            };
            IdentityResult result = await _userManager.CreateAsync(appUser,newuser.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            await _signInManager.SignInAsync(appUser,false);
            return RedirectToAction("Home","Index");
            
        }

    }
}
