using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Persistence;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;

namespace PizzaMVCApplication.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SizeController(ISizeService sizeService, IWebHostEnvironment hostingEnvironment)
        {
            _sizeService = sizeService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _sizeService.GetAll().Select(size => new SizeIndexViewModel
            {
                SizeId = size.SizeId,
                Display = size.Display
            });
            return View(model.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IList<SizeIndexViewModel> model, string buttonType)
        {
            if (buttonType == "delete")
            {
                Delete(model);
            }
            else if (buttonType == "edit")
            {
                return DirectToEdit(model);
            }
            else if (buttonType == "info")
            {
                return DirectToInfo(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeCreateViewModel model)
        {
            Size size = new Size
            {
                SizeId = model.SizeId,
                Display = model.Display
            };
            await _sizeService.CreateAsync(size);
            return RedirectToAction("Create");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchModel(SizeSearchViewModel model)
        {
            Size size = new Size
            {
                SizeId = model.SizeId,
                Display = model.Display
            };
            IEnumerable<Size> list = _sizeService.Search(size);
            var newModel = list.Select(size => new SizeIndexViewModel
            {
                SizeId = size.SizeId,
                Display = size.Display
            });
            return View("Index", newModel.ToList());
        }

        public IActionResult Info()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Info(SizeInfoViewModel model)
        {
            Size size = new Size
            {
                SizeId = model.SizeId,
                Display = model.Display
            };
            return View(model);
        }

        public IActionResult Edit()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SizeEditViewModel model, string buttonType)
        {
            Size size = new Size
            {
                SizeId = model.SizeId,
                Display = model.Display
            };

            if (buttonType == "edit")
            {
                await _sizeService.UpdateAsync(size);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int SizeId)
        {
            var size = _sizeService.GetById(SizeId);
            var model = new SizeEditViewModel()
            {
                SizeId = (int) size.SizeId,
                Display = size.Display
            };
            return View(model);
        }

        public IActionResult DirectToInfo(IList<SizeIndexViewModel> model)
        {
            SizeIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                SizeInfoViewModel infoModel = new SizeInfoViewModel
                {
                    SizeId = (int) obj.SizeId,
                    Display = obj.Display
                };
                return View("Info", infoModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToEdit(IList<SizeIndexViewModel> model)
        {
            SizeIndexViewModel obj = getFirstCheckedModel(model);
            
            if (obj != null) {
                SizeEditViewModel editModel = new SizeEditViewModel
                {
                    SizeId = (int) obj.SizeId,
                    Display = obj.Display
                };
                return View("Edit", editModel);
            }

            return RedirectToAction("Index");
        }

        public SizeIndexViewModel getFirstCheckedModel(IList<SizeIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }

        public async Task Delete(IList<SizeIndexViewModel> model)
        {
            List<int> list = getCheckedIdList(model);

            _sizeService.DeleteAsync(list);
        }

        public List<int> getCheckedIdList(IList<SizeIndexViewModel> model)
        {
            List<int> list = new List<int>();
            foreach (SizeIndexViewModel obj in model)
            {
                if (obj.Checked)
                {
                    list.Add((int) obj.SizeId);
                }
            }
            return list;
        }
    }
}
