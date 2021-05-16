using DreamTeamProject.Data.Models;
using DreamTeamProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult CreateOrderPost([FromForm] Order order)
        {
            bool result = this.orderService.AddOrder(order);
            if (!result)
            {
                return RedirectToAction("GetAllBooks", "Book");
            }
            return RedirectToAction("CreateOrder");
        }
    }
}
