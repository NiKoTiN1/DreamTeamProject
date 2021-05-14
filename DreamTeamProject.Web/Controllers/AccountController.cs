using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamTeamProject.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        private readonly IAccountService accountService;

        [HttpGet]
        [Route("register")]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrationPost([FromForm] LoginViewModel vm)
        {
            string registationResult = this.accountService.Registration(vm.Surname, vm.Password);
            if (registationResult != null)
            {
                return BadRequest(registationResult);
            }
            return Ok();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost([FromForm] LoginViewModel vm)
        {
            string resultLogin = this.accountService.Login(vm.Surname, vm.Password);
            try
            {
                int userId = Convert.ToInt32(resultLogin);
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString())
                };
                var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                User user = this.accountService.GetUser(userId);
                return RedirectToAction("AllBooks", "Books");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(resultLogin);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("logout")]
        public virtual async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
            return Ok();
        }
    }
}
