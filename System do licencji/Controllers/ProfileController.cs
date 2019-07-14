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
        public async Task<IActionResult> Edit(PlayerEditVM playerEditVM)
        {
            if (ModelState.IsValid)
            {
                Player player = await _userManager.GetUserAsync(HttpContext.User);

                player.Name = playerEditVM.Name;
                player.UserName = playerEditVM.UserName;
                player.Email = playerEditVM.Email;
                player.Surname = playerEditVM.Surname;
                player.Street = playerEditVM.Street;
                player.City = playerEditVM.City;


                await _userManager.UpdateAsync(player);


                return RedirectToAction("Index");
            }
           

            return View(new PlayerEditVM());
        }
    }
}