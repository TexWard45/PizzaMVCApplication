using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Persistence;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace PizzaMVCApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OrderController(IOrderService orderService, IStatusService statusService,IWebHostEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _statusService = statusService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            var model = _orderService.GetAll().Select(order => new OrderIndexViewModel
            {
                OrderId = order.OrderId,
                StartStatusDetail = _statusService.GetByStatusId(order.OrderId,1),
                EndStatusDetail = _statusService.GetLastStatusDetail(order.OrderId),
                EndStatus = _statusService.GetById(order.OrderId),
                CustomerUsername = order.CustomerUsername,
                HandlerUsername = order.HandlerUsername,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
            }); 
            return View(model.ToList());
        }
        public IActionResult Search()
        {
            OrderSearchViewModel objSearchView = new OrderSearchViewModel()
            {
                startDay = DateTime.Now,
                endDay = DateTime.Now
            };
            return View(objSearchView);
        }
        [HttpGet]
        public IActionResult SearchModel(OrderSearchViewModel model)
        {
            
            IEnumerable<Order> listOrder = _orderService.Search(model.startDay, model.endDay);
            var newModel = listOrder.Select(order => new OrderIndexViewModel
            {
                OrderId = order.OrderId,
                StartStatusDetail = _statusService.GetByStatusId(order.OrderId, 1),
                EndStatusDetail = _statusService.GetLastStatusDetail(order.OrderId),
                EndStatus = _statusService.GetById(order.OrderId),
                CustomerUsername = order.CustomerUsername,
                HandlerUsername = order.HandlerUsername,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
            });
            return View("Index", newModel.ToList());
        }
    }
}
