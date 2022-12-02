using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Entity;

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
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult ToSearch()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Display = ""
            };
            return PartialView("_ModalSearch",model);
        }

        [HttpGet]
        public IActionResult ToInfo(List<int> data)
        {
            if (data.Count > 0)
            {
                int CategoryId = data[0];
                CategoryViewModel model = new CategoryViewModel
                {
                    Display = _categoryService.GetById(CategoryId).Display,
                };
                return PartialView("_ModalInfo", model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ToEdit(List<int> data)
        {
            if (data.Count > 0)
            {
                int CategoryId = data[0];
                CategoryViewModel model = new CategoryViewModel
                {
                    CategoryId =CategoryId,
                };
                return PartialView("_ModalEdit", model);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ToDelete(List<int> data)
        {
            if (data.Count > 0)
            {
                CategoryViewModel model = new CategoryViewModel
                {
                    Display = "",
                    arrayId = data
                };
                return PartialView("_ModalDelete", model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ToAdd()
        {
            CategoryViewModel model = new CategoryViewModel
            {
                Display = ""
            };
            return PartialView("_ModalAdd",model);
        }
        
        [HttpGet]
        public IActionResult SearchCategory(CategoryViewModel view)
        {
            var model = _categoryService.SearchByName(view.Display).Select(category => new CategoryIndexViewModel
            {
                CategoryId = category.CategoryId,
                Display = category.Display,
            }).ToList();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            if (_categoryService.GetByName(model.Display) != null)
                return RedirectToAction("Index");
            Category category = new Category
            {
                Display = model.Display
            };
            
            await _categoryService.CreateAsync(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryViewModel model)
        {
            if (_categoryService.GetByName(model.Display) != null)
                return RedirectToAction("Index");
            Category category = new Category
            {
                CategoryId = model.CategoryId,
                Display = model.Display
            };
            await _categoryService.UpdateAsync(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryViewModel model)
        {
            await _categoryService.DeleteCategories(model.arrayId);
            return RedirectToAction("Index");
        }
    }
}
