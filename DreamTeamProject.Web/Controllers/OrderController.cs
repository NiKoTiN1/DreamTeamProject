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
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        private readonly IOrderService orderService;

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
    }
}
