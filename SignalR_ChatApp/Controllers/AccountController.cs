using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SignalR_ChatApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }

        [HttpPost]
        public IActionResult Login(Pages.LoginModel lm)
        {
            if (ModelState.IsValid)
            {
                var result = _SignInManager.PasswordSignInAsync();
            }
            return View(lm);
        }
    }
}