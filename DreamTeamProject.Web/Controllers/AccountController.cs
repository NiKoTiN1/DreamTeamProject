using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamTeamProject.Web.Controllers
{
    [Route("{controllerName}")]
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
        [Route("register-post")]
        public IActionResult RegistrationPost([FromForm] RegisterViewModel vm)
        {
            var customer = new Customer()
            {
                Email = vm.Email,
                Name = vm.Name,
                Phone = vm.Phone,
                SurName = vm.SurName,
            };
            string registationResult = this.accountService.Registration(customer, vm.Password);
            if (registationResult != null)
            {
                return RedirectToAction("Registration");
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
        [Route("login-post")]
        public async Task<IActionResult> LoginPost([FromForm] LoginViewModel vm)
        {
            string resultLogin = this.accountService.Login(vm.Email, vm.Password);
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
                return RedirectToAction("all", "Books");
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

        [HttpGet]
        [Authorize]
        [Route("all-users")]
        public IActionResult GetAllUsers()
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login");
            }
            if (!this.accountService.IsAdmin(userIdClaim.Value))
            {
                return BadRequest("You are not Admin!");
            }
            var allUsers = this.accountService.GetAllUsers();
            if(allUsers == null)
            {
                return BadRequest();
            }
            return View(allUsers);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChangeRole([FromForm] ChangeRoleViewModel model)
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login");
            }
            if (!this.accountService.IsAdmin(userIdClaim.Value))
            {
                return BadRequest("You are not Admin!");
            }
            var newCustomer = this.accountService.ChangeRole(model.Id, model.RoleId);
            if(newCustomer == null)
            {
                return RedirectToAction("All", "Book");
            }
            return RedirectToAction("GetAllUsers");
        }
    }
}
