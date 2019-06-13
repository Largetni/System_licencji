using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System_do_licencji.ViewModels;
using System_do_licencji.Models;
using System_do_licencji.Areas.Identity.Pages.Account;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace System_do_licencji.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Player> _signInManager;
        private readonly UserManager<Player> _userManager;

        public AccountController(SignInManager<Player> signInManager, UserManager<Player> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile");
                }

            }

            ModelState.AddModelError("", "Nazwa użytkowninka lub hasło jest nieprawidłowe");

            return View(loginVM);
            
        }

        public IActionResult Register()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile");
                }
            }

            ModelState.AddModelError("", "Rejestracja nieudana");

            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

}
}
