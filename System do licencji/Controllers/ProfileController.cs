using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System_do_licencji.Models;
using Microsoft.AspNetCore.Http;
using System_do_licencji.ViewModels;

namespace System_do_licencji.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signInManager;

        public ProfileController(UserManager<Player> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (userId == null)
                return RedirectToAction("Login", "Account");
            else
            {
                Player user = _userManager.FindByIdAsync(userId).Result;
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            
            Player player = _userManager.FindByIdAsync(id).Result;
            PlayerEditVM playerEditVM=new PlayerEditVM
            {
               UserName = player.UserName,
                Email = player.Email,
                Name = player.Name,
                Surname = player.Surname,
                Street = player.Street,
                City = player.City
            };

            return View(playerEditVM);
        }

        [HttpPost]
        public IActionResult Edit(PlayerEditVM playerEditVM)
        {
            if (ModelState.IsValid)
            {
                Player player = _userManager.GetUserAsync(playerEditVM.);

                var user = new Player()
                {
                    UserName = playerEditVM.UserName,
                    Email = playerEditVM.Email,
                    Name = playerEditVM.Name,
                    Surname = playerEditVM.Surname,
                    Street = playerEditVM.Street,
                    City = playerEditVM.City,
                   
                };
              //  var result = await _userManager.CreateAsync(user, playerEditVM.Password);

                if (result.Succeeded)
                {




                    return RedirectToAction("Index", "Profile", new { userID = user.Id });
                }
            }
            ModelState.AddModelError("", "Edycja nieudana");

            return View(new RegisterVM());
        }
    }
}