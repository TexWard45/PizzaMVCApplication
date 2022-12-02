using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Persistence;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;

namespace PizzaMVCApplication.Controllers
{
    public class BaseController : Controller
    {
        private readonly IBaseService _BaseService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BaseController(IBaseService BaseService, IWebHostEnvironment hostingEnvironment)
        {
            _BaseService = BaseService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var model = _BaseService.GetAll().Select(Base => new BaseIndexViewModel
            {
                BaseId = Base.BaseId,
                Display = Base.Display
            });
            return View(model.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IList<BaseIndexViewModel> model, string buttonType)
        {
            if (buttonType == "delete")
            {
                await Delete(model);
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
        public async Task<IActionResult> Create(BaseCreateViewModel model)
        {
            Base Base = new Base
            {
                BaseId = model.BaseId,
                Display = model.Display
            };
            await _BaseService.CreateAsync(Base);
            return RedirectToAction("Create");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchModel(BaseSearchViewModel model)
        {
            Base Base = new Base
            {
                BaseId = model.BaseId,
                Display = model.Display
            };
            IEnumerable<Base> list = _BaseService.Search(Base);
            var newModel = list.Select(Base => new BaseIndexViewModel
            {
                BaseId = Base.BaseId,
                Display = Base.Display
            });
            return View("Index", newModel.ToList());
        }

        public IActionResult Info()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Info(BaseInfoViewModel model)
        {
            Base Base = new Base
            {
                BaseId = model.BaseId,
                Display = model.Display
            };
            return View(model);
        }

        public IActionResult Edit()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BaseEditViewModel model, string buttonType)
        {
            Base Base = new Base
            {
                BaseId = model.BaseId,
                Display = model.Display
            };

            if (buttonType == "edit")
            {
                await _BaseService.UpdateAsync(Base);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int BaseId)
        {
            var Base = _BaseService.GetById(BaseId);
            var model = new BaseEditViewModel()
            {
                BaseId = (int)Base.BaseId,
                Display = Base.Display
            };
            return View(model);
        }

        public IActionResult DirectToInfo(IList<BaseIndexViewModel> model)
        {
            BaseIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                BaseInfoViewModel infoModel = new BaseInfoViewModel
                {
                    BaseId = (int)obj.BaseId,
                    Display = obj.Display
                };
                return View("Info", infoModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToEdit(IList<BaseIndexViewModel> model)
        {
            BaseIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                BaseEditViewModel editModel = new BaseEditViewModel
                {
                    BaseId = (int)obj.BaseId,
                    Display = obj.Display
                };
                return View("Edit", editModel);
            }

            return RedirectToAction("Index");
        }

        public BaseIndexViewModel getFirstCheckedModel(IList<BaseIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }

        public async Task Delete(IList<BaseIndexViewModel> model)
        {
            List<int> list = getCheckedIdList(model);

            await _BaseService.DeleteAsync(list);
        }

        public List<int> getCheckedIdList(IList<BaseIndexViewModel> model)
        {
            List<int> list = new List<int>();
            foreach (BaseIndexViewModel obj in model)
            {
                if (obj.Checked)
                {
                    list.Add((int)obj.BaseId);
                }
            }
            return list;
        }
    }
}
