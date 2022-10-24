using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Persistence;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;
namespace PizzaMVCApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OrderController(IOrderService orderService, IWebHostEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = _orderService.GetAll().Select(order => new OrderIndexViewModel
            {
                OrderId = order.OrderId,
                CustomerUsername = order.CustomerUsername,
                HandlerUsername = order.HandlerUsername,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
            });
            return View(model.ToList());
        }

        
    }
}
