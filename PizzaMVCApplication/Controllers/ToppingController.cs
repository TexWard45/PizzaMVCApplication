using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
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
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult ToSearch()
        {
            ToppingViewModel model = new ToppingViewModel
            {
                Display = ""
            };
            return PartialView("_ModalSearch", model);
        }

        [HttpGet]
        public IActionResult ToInfo(List<int> data)
        {
            if (data.Count > 0)
            {
                int ToppingId = data[0];
                ToppingViewModel model = new ToppingViewModel
                {
                    Display = _toppingService.GetById(ToppingId).Display,
                };
                return PartialView("_ModalInfo", model);
            }
            return RedirectToAction("Index");
        }
        public IActionResult ToEdit(List<int> data)
        {
            if (data.Count > 0)
            {
                int ToppingId = data[0];
                ToppingViewModel model = new ToppingViewModel
                {
                    ToppingId = ToppingId,
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
                ToppingViewModel model = new ToppingViewModel
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
            ToppingViewModel model = new ToppingViewModel
            {
                Display = ""
            };
            return PartialView("_ModalAdd", model);
        }

        [HttpGet]
        public IActionResult SearchTopping(ToppingViewModel view)
        {
            var model = _toppingService.SearchByName(view.Display).Select(topping => new ToppingIndexViewModel
            {
                ToppingId = topping.ToppingId,
                Display = topping.Display,
            }).ToList();
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTopping(ToppingViewModel model)
        {
            if (_toppingService.GetByName(model.Display) != null)
                return RedirectToAction("Index");
            Topping topping = new Topping
            {
                Display = model.Display
            };

            await _toppingService.CreateAsync(topping);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditTopping(ToppingViewModel model)
        {
            if (_toppingService.GetByName(model.Display) != null)
                return RedirectToAction("Index");
            Topping topping = new Topping
            {
                ToppingId = model.ToppingId,
                Display = model.Display
            };
            await _toppingService.UpdateAsync(topping);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTopping(ToppingViewModel model)
        {
            await _toppingService.DeleteToppings(model.arrayId);
            return RedirectToAction("Index");
        }
    }
}
