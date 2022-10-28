using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;

namespace PizzaMVCApplication.Controllers
{
    public class ToppingController : Controller
    {
        private readonly IToppingService _toppingService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ToppingController(IToppingService toppingService, IWebHostEnvironment hostingEnvironment)
        {
            _toppingService = toppingService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = _toppingService.GetAll().Select(topping => new ToppingIndexViewModel
            {
                ToppingId = topping.ToppingId,
                Display = topping.Display,
     
            });
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
