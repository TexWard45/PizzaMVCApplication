using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;

namespace PizzaMVCApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public CategoryController(ICategoryService categoryService, IWebHostEnvironment hostingEnvironment)
        {
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = _categoryService.GetAll().Select(category => new CategoryIndexViewModel
            {
                CategoryId = category.CategoryId,
                Display = category.Display,

            });
            return View(model);
        }
    }
}
