using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;

namespace PizzaMVCApplication.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly ICategoryService _categoryService;
        private readonly ISizeService _sizeService;
        private readonly IBaseService _baseService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PizzaController(IPizzaService pizzaService, ICategoryService categoryService, ISizeService sizeService, IBaseService baseService, IWebHostEnvironment hostingEnvironment)
        {
            _pizzaService = pizzaService;
            _categoryService = categoryService;
            _sizeService = sizeService;
            _baseService = baseService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var model = _pizzaService.GetAll().Select(pizza => new PizzaIndexViewModel
            {
                PizzaId = pizza.Id,
                ImageUrl = pizza.Image,
                Display = pizza.Display,
                CategoryDisplay = _categoryService.GetById(pizza.CategoryId).Display,
                Description = pizza.Description,
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IList<PizzaIndexViewModel> model, string buttonType)
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

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchModel(PizzaSearchViewModel model)
        {
            Pizza pizza = new Pizza
            {
                Display = model.Display
            };
            IEnumerable<Pizza> list = _pizzaService.Search(pizza);

            var newModel = list.Select(user => new PizzaIndexViewModel
            {
                PizzaId = pizza.Id,
                ImageUrl = pizza.Image,
                Display = pizza.Display,
                CategoryDisplay = _categoryService.GetById(pizza.CategoryId).Display,
                Description = pizza.Description,
            });
            return View("Index", newModel.ToList());
        }

        public async Task Delete(IList<PizzaIndexViewModel> model)
        {
            List<int?> list = getCheckedIdList(model);

            await _pizzaService.DeleteAsync(list);
        }

        public List<int?> getCheckedIdList(IList<PizzaIndexViewModel> model)
        {
            List<int?> list = new List<int?>();
            foreach (PizzaIndexViewModel obj in model)
            {
                if (obj.Checked)
                {
                    list.Add(obj.PizzaId);
                }
            }
            return list;
        }

        public IActionResult DirectToEdit(IList<PizzaIndexViewModel> model)
        {
            PizzaIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                Pizza Pizza = _pizzaService.GetById(obj.PizzaId);
                PizzaEditViewModel editModel = new PizzaEditViewModel
                {
                    PizzaId = Pizza.Id,
                    Display = Pizza.Display,
                    CategoryList = _categoryService.GetAllToSelectListItem(),
                    Description = Pizza.Description,
                };

                IList<PizzaEditSizeBaseViewModel> SizeBaseList = new List<PizzaEditSizeBaseViewModel>();

                IEnumerable<Base> bases = _baseService.GetAll();
                foreach (Size size in _sizeService.GetAll())
                {
                    foreach (Base basee in bases)
                    {
                        SizeBaseList.Add(new PizzaEditSizeBaseViewModel
                        {
                            SizeId = size.SizeId,
                            SizeDisplay = size.Display,
                            BaseId = basee.BaseId,
                            BaseDisplay = basee.Display,
                            Price = 0,
                            Quantity = 0
                        });
                    }
                }

                IEnumerable<PizzaDetail> PizzaDetails = _pizzaService.GetAllPizzaDetail(Pizza.Id);
                foreach (PizzaEditSizeBaseViewModel EditModel in SizeBaseList)
                {
                    foreach (PizzaDetail PizzaDetail in PizzaDetails)
                    {
                        if (PizzaDetail.SizeId == EditModel.SizeId && PizzaDetail.BaseId == EditModel.BaseId)
                        {
                            EditModel.Price = PizzaDetail.Price;
                            EditModel.Quantity = PizzaDetail.Quantity;
                        }
                    }
                }

                editModel.SizeBaseList = SizeBaseList;
                return View("Edit", editModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToInfo(IList<PizzaIndexViewModel> model)
        {
            PizzaIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                Pizza Pizza = _pizzaService.GetById(obj.PizzaId);
                PizzaInfoViewModel infoModel = new PizzaInfoViewModel
                {
                    PizzaId = Pizza.Id,
                    ImageUrl = Pizza.Image,
                    Display = Pizza.Display,
                    CategoryDisplay = _categoryService.GetById(Pizza.CategoryId).Display,
                    Description = Pizza.Description,
                };

                IList<PizzaInfoSizeBaseViewModel> SizeBaseList = new List<PizzaInfoSizeBaseViewModel>();

                IEnumerable<PizzaDetail> PizzaDetails = _pizzaService.GetAllPizzaDetail(Pizza.Id);

                foreach (PizzaDetail PizzaDetail in PizzaDetails)
                {
                    SizeBaseList.Add(new PizzaInfoSizeBaseViewModel
                    {
                        SizeId = PizzaDetail.SizeId,
                        SizeDisplay = PizzaDetail.Size.Display,
                        BaseId = PizzaDetail.BaseId,
                        BaseDisplay = PizzaDetail.Base.Display,
                        Price = PizzaDetail.Price,
                        Quantity = PizzaDetail.Quantity
                    });
                }
                infoModel.SizeBaseList = SizeBaseList;
                return View("Info", infoModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            IList<PizzaCreateSizeBaseViewModel> SizeBaseList = new List<PizzaCreateSizeBaseViewModel>();

            IEnumerable<Base> bases = _baseService.GetAll();
            foreach (Size size in _sizeService.GetAll())
            {
                foreach (Base basee in bases)
                {
                    SizeBaseList.Add(new PizzaCreateSizeBaseViewModel
                    {
                        SizeId = size.SizeId,
                        SizeDisplay = size.Display,
                        BaseId = basee.BaseId,
                        BaseDisplay = basee.Display,
                        Price = 0,
                        Quantity = 0
                    });
                }
            }

            var model = new PizzaCreateViewModel
            {
                CategoryList = _categoryService.GetAllToSelectListItem(),
                SizeBaseList = SizeBaseList
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PizzaCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Pizza Pizza = new Pizza
                {
                    Display = model.Display,
                    Description = model.Description,
                    CategoryId = model.CategoryId
                };
                if (model.ImageUrl != null & model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/pizza";
                    var filename = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webrootPath = _hostingEnvironment.WebRootPath;
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + extension;
                    var path = Path.Combine(webrootPath, uploadDir, filename);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    Pizza.Image = "/" + uploadDir + "/" + filename;
                }

                await _pizzaService.CreatePizzaAsync(Pizza);

                foreach (PizzaCreateSizeBaseViewModel Detail in model.SizeBaseList)
                {
                    await _pizzaService.CreateOrUpdatePizzaDetailAsync(new PizzaDetail
                    {
                        PizzaId = Pizza.Id,
                        SizeId = Detail.SizeId,
                        BaseId = Detail.BaseId,
                        Price = Detail.Price,
                        Quantity = Detail.Quantity,
                    });
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public PizzaIndexViewModel getFirstCheckedModel(IList<PizzaIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }
    }
}
