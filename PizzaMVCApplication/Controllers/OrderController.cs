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
        private readonly IPizzaService _pizzaService;
        private readonly ISizeService _sizeService;
        private readonly IBaseService _baseService;    
        private readonly IWebHostEnvironment _hostingEnvironment;
        public OrderController(IOrderService orderService, IStatusService statusService, IPizzaService pizzaService,
            ISizeService sizeService, IBaseService baseService, IWebHostEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _statusService = statusService;
            _pizzaService = pizzaService;
            _sizeService = sizeService;
            _baseService = baseService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = _orderService.GetAll().Select(order => new OrderIndexViewModel
            {
                OrderId = order.OrderId,
                StartStatusDetail = _statusService.GetByStatusId(order.OrderId,1),
                EndStatusDetail = _statusService.GetLastStatusDetail(order.OrderId),
                EndStatus = _statusService.GetByOrderId(order.OrderId),
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
                EndStatus = _statusService.GetByOrderId(order.OrderId),
                CustomerUsername = order.CustomerUsername,
                HandlerUsername = order.HandlerUsername,
                TotalPrice = order.TotalPrice,
                Quantity = order.Quantity,
            });
            return View("Index", newModel.ToList());
        }

        public IActionResult ToCheck(List<int> data)
        {      
            if (data.Count>0)
            {
                ViewBag.OrderId = data[0];           
                return PartialView("_ModalViewCheck");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Check(int OrderId)
        {
            string result = "";
            StatusDetail EndStatusDetail = _statusService.GetLastStatusDetail(OrderId);
            if (EndStatusDetail.StatusId == 6) {
                result = "Không thể kiểm tra đơn hàng đã hoàn tất!";
            }
            if (EndStatusDetail.StatusId == 7) {
                result = "Không thể kiểm tra đơn hàng đã bị hủy!";     
            }
            IEnumerable<OrderDetail> listOrderDetail = _orderService.GetListOrderDetail(OrderId);
            return Content(result);
        }

        public IActionResult ToInfo(List<int> data)
        {
            if (data.Count > 0)
            {
                int OrderId = data[0];
                Order order = _orderService.GetById(OrderId);
                IEnumerable<StatusDetail> listStatusDetail = _statusService.GetListStatusDetail(OrderId, 7);
                IEnumerable<OrderDetail> listOrderDetail = _orderService.GetListOrderDetail(OrderId);
                IEnumerable<Status> listStatus = _statusService.GetAll();


                //xử lý OrderDetailViewModel
                List<OrderDetailViewModel> details = new List<OrderDetailViewModel>();
                double total = 0;
                foreach (OrderDetail orderDetail in listOrderDetail)
                {
                    PizzaDetail pizzaDetail = _pizzaService.GetByPizzaDetailId(orderDetail.PizzaDetailId);

                    double amount = orderDetail.Price * orderDetail.Quantity;
                    total += amount;
                    OrderDetailViewModel orderDetailViewModel = new OrderDetailViewModel
                    {
                        DisplayPizza = _pizzaService.GetById(pizzaDetail.PizzaId).Display,
                        DisplaySize = _sizeService.GetById(pizzaDetail.SizeId).Display,
                        DisplayBase = _baseService.GetById(pizzaDetail.BaseId).Display,
                        Price = orderDetail.Price,
                        Quantity = orderDetail.Quantity,
                        Amount = amount
                    };
                    details.Add(orderDetailViewModel);
                }



                OrderInfoViewModel infoModel = new OrderInfoViewModel
                {
                    Fullname = order.Fullname,
                    Address = order.Address,
                    Phone = order.Phone,
                    PaymentType = order.PaymentType,
                    OrderType = order.OrderType,
                    OrderTime = order.OrderTime,
                    Note = order.Note,
                    ListStatusDetail = listStatusDetail,
                    ListOrderDetail = listOrderDetail,
                    ListStatus = listStatus,
                    OrderDetailViewModel = details,
                    Total = total,
                };

                return PartialView("_ModalViewInfo", infoModel);
            }
            return RedirectToAction("Index");
        }


        public OrderIndexViewModel getFirstCheckedModel(IList<OrderIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }

        
    }
}
