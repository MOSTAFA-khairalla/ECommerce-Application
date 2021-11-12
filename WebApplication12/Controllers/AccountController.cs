using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Model.Context;
using WebApplication12.Model.ViewModel;

namespace WebApplication12.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,ILogger<AccountController> logger )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
      
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration( RegisterationVM  model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email= model.Email
                };
          var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }

            }
            return View( model );
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login( LoginVM login)
        {
            if (ModelState.IsValid)
            {
                 var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe=true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("ShopCart", "ShopCart");
                }
                else
                {
                    ModelState.AddModelError("", "invalid UserName and Password");
                }

            }
            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forget)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(forget.Email);
                if (user!=null)
                {
                    var Token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var PasswordRestLink = Url.Action("RestPassword", "Account",new { Email = forget.Email, Token=Token },Request.Scheme);
                    _logger.Log(LogLevel.Warning, PasswordRestLink);
                    return RedirectToAction("ConfrimforgetPassword");
                }
               

            }
            return View(forget);
        }

        public IActionResult ConfrimforgetPassword()
        {
            return View();
        }

    

        public IActionResult RestPassword( string Email, string Token )
        {
            if (Email==null||Token==null)
            {
                ModelState.AddModelError("", "Invalid Data");
            }
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RestPassword(ResetPasswordVM resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(resetPassword.Email);
                if (user!=null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                        return View(resetPassword);

                    }

                }
                return RedirectToAction("Login");

            }

            return View(resetPassword);
        }

    }
}
