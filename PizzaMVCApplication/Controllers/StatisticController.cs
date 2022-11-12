using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;

namespace PizzaMVCApplication.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IStatusService _statusService;
        private readonly IPizzaService _pizzaService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public StatisticController(IOrderService orderService, IStatusService statusService, IPizzaService pizzaService,
             ICategoryService categoryService, IWebHostEnvironment hostingEnvironment)
        {
            _orderService = orderService;
            _statusService = statusService;
            _pizzaService = pizzaService;    
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            StatisticByCategoryViewModel model = new StatisticByCategoryViewModel();
            var details = (from orderDetail in _orderService.GetAllDetail()
                           join pizzaDetail in _pizzaService.GetAllDetail()
                           on orderDetail.PizzaDetailId equals pizzaDetail.Id
                           join pizza in _pizzaService.GetAll()
                           on pizzaDetail.PizzaId equals pizza.Id
                           join category in _categoryService.GetAll()
                           on pizza.CategoryId equals category.CategoryId
                           join statusDetail in _statusService.GetAllDetail()
                           on orderDetail.OrderId equals statusDetail.OrderId
                           where (statusDetail.StatusId == 1)
                           select new
                           {
                               OrderId = orderDetail.OrderId,
                               CategoryId = category.CategoryId,
                               Price = orderDetail.Price,
                               Quantity = orderDetail.Quantity,
                           }).ToList();

            IEnumerable<Category> categories = _categoryService.GetAll();
            model.Categories = categories;
            model.TotalActualRevenue = 0;
            model.TotalExpectedRevenue = 0;
            model.TotalActualSales = 0;
            model.TotalExpectedSales = 0;
            model.ActualRevenue = new List<double>();
            model.ExpectedRevenue = new List<double>();
            model.ActualSales = new List<int>();
            model.ExpectedSales = new List<int>();
            foreach (Category category in categories)
            {
                // doanh thu
                double actual1 = 0;
                double expected1 = 0;

                // so luong ban
                int actual2 = 0;
                int expected2 = 0;

                foreach (var detail in details)
                {
                    int? OrderId = detail.OrderId;
                    int? CatetoryId = detail.CategoryId;
                    double Price = detail.Price;
                    int Quantity = detail.Quantity;
                    if (CatetoryId != category.CategoryId)
                        continue;
                    StatusDetail statusDetail = _statusService.GetLastStatusDetail(OrderId);

                    if (statusDetail.StatusId == 6)
                    {
                        actual1 += Price * Quantity;
                        actual2 += Quantity;
                    }

                    if (statusDetail.StatusId < 6)
                    {
                        expected1 += Price * Quantity;
                        expected2 += Quantity;
                    }
                }

                model.ActualRevenue.Add(actual1);
                model.ActualSales.Add(actual2);
                model.ExpectedRevenue.Add(expected1);
                model.ExpectedSales.Add(expected2);

                model.TotalActualRevenue += actual1;
                model.TotalActualSales += actual2;
                model.TotalExpectedRevenue += expected1;
                model.TotalExpectedSales += expected2;
            }

            return View("StatisticByCategory",model);
        }

        public IActionResult Pizza()
        {
            StatisticByPizzaViewModel model = new StatisticByPizzaViewModel();
            var details = (from orderDetail in _orderService.GetAllDetail()
                           join pizzaDetail in _pizzaService.GetAllDetail()
                           on orderDetail.PizzaDetailId equals pizzaDetail.Id
                           join pizza in _pizzaService.GetAll()
                           on pizzaDetail.PizzaId equals pizza.Id
                           join statusDetail in _statusService.GetAllDetail()
                           on orderDetail.OrderId equals statusDetail.OrderId
                           where (statusDetail.StatusId == 1)
                           select new
                           {
                               OrderId = orderDetail.OrderId,
                               PizzaId = pizza.Id,
                               Price = orderDetail.Price,
                               Quantity = orderDetail.Quantity,
                           } into x
                           group x by new { x.OrderId, x.PizzaId } into g
                           select new
                           {
                               OrderId = g.Key.OrderId,
                               PizzaId = g.Key.PizzaId,
                               TotalPrice = g.Sum(i => i.Price * i.Quantity),
                               TotalQuantity = g.Sum(i => i.Quantity),
                           }).ToList();
            IEnumerable<Pizza> pizzas = _pizzaService.GetAll();
            model.Pizzas = pizzas;
            model.TotalActualRevenue = 0;
            model.TotalExpectedRevenue = 0;
            model.TotalActualSales = 0;
            model.TotalExpectedSales = 0;
            model.ActualRevenue = new List<double>();
            model.ExpectedRevenue = new List<double>();
            model.ActualSales = new List<int>();
            model.ExpectedSales = new List<int>();
            foreach (Pizza pizza in pizzas)
            {
                // doanh thu
                double actual1 = 0;
                double expected1 = 0;

                // so luong ban
                int actual2 = 0;
                int expected2 = 0;

                foreach (var detail in details)
                {
                    int? OrderId = detail.OrderId;
                    int? PizzaId = detail.PizzaId;
                    double Price = detail.TotalPrice;
                    int Quantity = detail.TotalQuantity;
                    if (PizzaId != pizza.Id)
                        continue;
                    StatusDetail statusDetail = _statusService.GetLastStatusDetail(OrderId);

                    if (statusDetail.StatusId == 6)
                    {
                        actual1 += Price;
                        actual2 += Quantity;
                    }

                    if (statusDetail.StatusId < 6)
                    {
                        expected1 += Price;
                        expected2 += Quantity;
                    }
                }

                model.ActualRevenue.Add(actual1);
                model.ActualSales.Add(actual2);
                model.ExpectedRevenue.Add(expected1);
                model.ExpectedSales.Add(expected2);

                model.TotalActualRevenue += actual1;
                model.TotalActualSales += actual2;
                model.TotalExpectedRevenue += expected1;
                model.TotalExpectedSales += expected2;
            }

            return View("StatisticByPizza",model);
        }

        public IActionResult SearchCategory()
        {

            return View("StatisticByPizza");
        }

        
        public IActionResult ToSearchCategory()
        {
            OrderSearchViewModel objSearchView = new OrderSearchViewModel()
            {
                startDay = DateTime.Now,
                endDay = DateTime.Now
            };
            return View("_ModalSearchByCategory", objSearchView);
        }

        public IActionResult ToSearchPizza()
        {
            OrderSearchViewModel objSearchView = new OrderSearchViewModel()
            {
                startDay = DateTime.Now,
                endDay = DateTime.Now
            };
            return View("_ModalSearchByPizza", objSearchView);
        }

        [HttpGet]
        public IActionResult SearchCategory(OrderSearchViewModel view)
        {
            StatisticByCategoryViewModel model = new StatisticByCategoryViewModel();
            var details = (from orderDetail in _orderService.GetAllDetail()
                           join pizzaDetail in _pizzaService.GetAllDetail()
                           on orderDetail.PizzaDetailId equals pizzaDetail.Id
                           join pizza in _pizzaService.GetAll()
                           on pizzaDetail.PizzaId equals pizza.Id
                           join category in _categoryService.GetAll()
                           on pizza.CategoryId equals category.CategoryId
                           join statusDetail in _statusService.GetAllDetail()
                           on orderDetail.OrderId equals statusDetail.OrderId
                           where (statusDetail.StatusId == 1 &&
                                  statusDetail.TimeCreated >= view.startDay &&
                                  statusDetail.TimeCreated <= view.endDay) 
                           select new
                           {
                               OrderId = orderDetail.OrderId,
                               CategoryId = category.CategoryId,
                               Price = orderDetail.Price,
                               Quantity = orderDetail.Quantity,
                           }).ToList();

            IEnumerable<Category> categories = _categoryService.GetAll();
            model.Categories = categories;
            model.TotalActualRevenue = 0;
            model.TotalExpectedRevenue = 0;
            model.TotalActualSales = 0;
            model.TotalExpectedSales = 0;
            model.ActualRevenue = new List<double>();
            model.ExpectedRevenue = new List<double>();
            model.ActualSales = new List<int>();
            model.ExpectedSales = new List<int>();
            foreach (Category category in categories)
            {
                // doanh thu
                double actual1 = 0;
                double expected1 = 0;

                // so luong ban
                int actual2 = 0;
                int expected2 = 0;

                foreach (var detail in details)
                {
                    int? OrderId = detail.OrderId;
                    int? CatetoryId = detail.CategoryId;
                    double Price = detail.Price;
                    int Quantity = detail.Quantity;
                    if (CatetoryId != category.CategoryId)
                        continue;
                    StatusDetail statusDetail = _statusService.GetLastStatusDetail(OrderId);

                    if (statusDetail.StatusId == 6)
                    {
                        actual1 += Price * Quantity;
                        actual2 += Quantity;
                    }

                    if (statusDetail.StatusId < 6)
                    {
                        expected1 += Price * Quantity;
                        expected2 += Quantity;
                    }
                }

                model.ActualRevenue.Add(actual1);
                model.ActualSales.Add(actual2);
                model.ExpectedRevenue.Add(expected1);
                model.ExpectedSales.Add(expected2);

                model.TotalActualRevenue += actual1;
                model.TotalActualSales += actual2;
                model.TotalExpectedRevenue += expected1;
                model.TotalExpectedSales += expected2;
            }

            return View("StatisticByCategory", model);
      
        }

        [HttpGet]
        public IActionResult SearchPizza(OrderSearchViewModel view)
        {
            StatisticByPizzaViewModel model = new StatisticByPizzaViewModel();
            var details = (from orderDetail in _orderService.GetAllDetail()
                           join pizzaDetail in _pizzaService.GetAllDetail()
                           on orderDetail.PizzaDetailId equals pizzaDetail.Id
                           join pizza in _pizzaService.GetAll()
                           on pizzaDetail.PizzaId equals pizza.Id
                           join statusDetail in _statusService.GetAllDetail()
                           on orderDetail.OrderId equals statusDetail.OrderId
                           where (statusDetail.StatusId == 1  &&
                                    statusDetail.TimeCreated >= view.startDay &&
                                    statusDetail.TimeCreated <= view.endDay)
                           select new
                           {
                               OrderId = orderDetail.OrderId,
                               PizzaId = pizza.Id,
                               Price = orderDetail.Price,
                               Quantity = orderDetail.Quantity,
                           } into x
                           group x by new { x.OrderId, x.PizzaId } into g
                           select new
                           {
                               OrderId = g.Key.OrderId,
                               PizzaId = g.Key.PizzaId,
                               TotalPrice = g.Sum(i => i.Price * i.Quantity),
                               TotalQuantity = g.Sum(i => i.Quantity),
                           }).ToList();
                    IEnumerable<Pizza> pizzas = _pizzaService.GetAll();
                    model.Pizzas = pizzas;
                    model.TotalActualRevenue = 0;
                    model.TotalExpectedRevenue = 0;
                    model.TotalActualSales = 0;
                    model.TotalExpectedSales = 0;
                    model.ActualRevenue = new List<double>();
                    model.ExpectedRevenue = new List<double>();
                    model.ActualSales = new List<int>();
                    model.ExpectedSales = new List<int>();
                    foreach (Pizza pizza in pizzas)
                    {
                        // doanh thu
                        double actual1 = 0;
                        double expected1 = 0;

                        // so luong ban
                        int actual2 = 0;
                        int expected2 = 0;

                        foreach (var detail in details)
                        {
                            int? OrderId = detail.OrderId;
                            int? PizzaId = detail.PizzaId;
                            double Price = detail.TotalPrice;
                            int Quantity = detail.TotalQuantity;
                            if (PizzaId != pizza.Id)
                                continue;
                            StatusDetail statusDetail = _statusService.GetLastStatusDetail(OrderId);

                            if (statusDetail.StatusId == 6)
                            {
                                actual1 += Price;
                                actual2 += Quantity;
                            }

                            if (statusDetail.StatusId < 6)
                            {
                                expected1 += Price;
                                expected2 += Quantity;
                            }
                        }

                model.ActualRevenue.Add(actual1);
                model.ActualSales.Add(actual2);
                model.ExpectedRevenue.Add(expected1);
                model.ExpectedSales.Add(expected2);

                model.TotalActualRevenue += actual1;
                model.TotalActualSales += actual2;
                model.TotalExpectedRevenue += expected1;
                model.TotalExpectedSales += expected2;
            }

            return View("StatisticByPizza", model);

        }

    }
}
