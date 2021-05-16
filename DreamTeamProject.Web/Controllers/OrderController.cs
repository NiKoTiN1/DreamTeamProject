using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using DreamTeamProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamTeamProject.Web.Controllers
{
    [Authorize]
    [Route("{controller}")]
    public class OrderController : Controller
    {
        public OrderController(IOrderService orderService, IAccountService accountService)
        {
            this.orderService = orderService;
            this.accountService = accountService;
        }

        private readonly IOrderService orderService;
        private readonly IAccountService accountService;

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!this.accountService.IsAdmin(userIdClaim.Value))
            {
                return BadRequest("You are not Admin!");
            }
            var orders = this.orderService.GetAllOrders();
            if (orders == null)
            {
                return RedirectToAction("GetAllBooks", "Book");
            }
            return View(orders);
        }

        [Route("create")]
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrderPost([FromForm] AddOrderViewModel model)
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login", "Account");
            }
            bool result = this.orderService.AddOrder(model.BookId, model.Address, model.PaymentMethod, Convert.ToInt32(userIdClaim.Value));
            if (!result)
            {
                return RedirectToAction("GetAllBooks", "Book");
            }
            return RedirectToAction("CreateOrder");
        }

        [HttpPost]
        public IActionResult AcceptOrder([FromForm] int orderId)
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!this.accountService.IsAdmin(userIdClaim.Value))
            {
                return BadRequest("You are not Admin!");
            }
            bool result = this.orderService.AcceptOrder(orderId);
            if (!result)
            {
                return RedirectToAction("GetAllBooks", "Book");
            }
            return RedirectToAction("GetAllOrders");
        }

        [HttpPost]
        public IActionResult RejectOrder([FromForm] int orderId)
        {
            Claim userIdClaim = HttpContext.User.Identities.First().Claims.First();
            if (userIdClaim.Value == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (!this.accountService.IsAdmin(userIdClaim.Value))
            {
                return BadRequest("You are not Admin!");
            }
            bool result = this.orderService.RejectOrder(orderId);
            if (!result)
            {
                return RedirectToAction("GetAllBooks", "Book");
            }
            return RedirectToAction("GetAllOrders");
        }
    }
}
