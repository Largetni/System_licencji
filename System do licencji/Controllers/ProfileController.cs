using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System_do_licencji.Models;

namespace System_do_licencji.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<Player> _userManager;

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
    }
}