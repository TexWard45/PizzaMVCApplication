using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;

namespace PizzaMVCApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserPermissionService _userPermissionService;
        private readonly IUserGroupService _userGroupService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UserController(IUserService userService, IUserGroupService userGroupService, IUserPermissionService userPermissionService, IWebHostEnvironment hostingEnvironment)
        {
            _userService = userService;
            _userGroupService = userGroupService;
            _hostingEnvironment = hostingEnvironment;
            _userPermissionService = userPermissionService;
        }

        public IActionResult Index() { 
            var model = _userService.GetAll().Select(user => new UserIndexViewModel { 
                Username = user.Username,
                Fullname = user.Fullname,
                GroupDisplay = user.UserGroup.Display,
                Birth = user.Birth,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email
            });
            return View(model.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IList<UserIndexViewModel> model, string buttonType)
        {
            if (buttonType == "delete")
            {
                await Delete(model);
            }
            else if (buttonType == "edit")
            {
                return DirectToEdit(model);
            }
            else if (buttonType == "permission")
            {
                return DirectToPermission(model);
            }
            else if (buttonType == "info")
            {
                return DirectToInfo(model);
            }
            return RedirectToAction("Index");
        }

        public async Task Delete(IList<UserIndexViewModel> model)
        {
            List<string> list = getCheckedIdList(model);

            await _userService.DeleteAsync(list);
        }

        public IActionResult DirectToEdit(IList<UserIndexViewModel> model)
        {
            UserIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                User user = _userService.GetByUsername(obj.Username);
                UserEditViewModel editModel = new UserEditViewModel
                {
                    Username = user.Username,
                    Password = user.Password,
                    RetypePassword = user.Password,
                    GroupId = user.UserGroupId,
                    GroupIdList = _userGroupService.GetAllToSelectListItem(user.UserGroupId),
                    Fullname = user.Fullname,
                    Birth = user.Birth,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email
                };
                return View("Edit", editModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToPermission(IList<UserIndexViewModel> model)
        {
            UserIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                string Username = obj.Username;
                IEnumerable<UserPermission> userPermissionList = _userPermissionService.GetPermissionsByUsername(Username);

                UserPermissionViewModel permissionModel = UserPermissionViewModel.From(Username, userPermissionList);
                return View("Permission", permissionModel);
            }

            return RedirectToAction("Index");
        }
        public IActionResult DirectToInfo(IList<UserIndexViewModel> model)
        {
            UserIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                User user = _userService.GetByUsername(obj.Username);
                UserInfoViewModel infoModel = new UserInfoViewModel
                {
                    Username = user.Username,
                    Password = user.Password,
                    RetypePassword = user.Password,
                    GroupDisplay = user.UserGroup.Display,
                    Fullname = user.Fullname,
                    Birth = user.Birth,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email
                };
                return View("Info", infoModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var model = new UserCreateViewModel
            {
                GroupIdList = _userGroupService.GetAllToSelectListItem(),
                Birth = DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (_userService.HasUsername(model.Username))
            {
                ModelState.AddModelError("Username", "Tên tài khoản này đã tồn tại");
            }
            if (model.Password != model.RetypePassword)
            {
                ModelState.AddModelError("RetypePassword", "Nhập lại mật khẩu không chính xác");
            }

            if (ModelState.IsValid) {
                User user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    UserGroupId = model.GroupId,
                    Fullname = model.Fullname,
                    Birth = model.Birth,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,
                };
                await _userService.CreateAsync(user);
                return RedirectToAction("Index");
            }

            model.GroupIdList = _userGroupService.GetAllToSelectListItem();
            return View(model);
        }

        public IActionResult Edit()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Permission()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model, string buttonType)
        {
            User user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Fullname = model.Fullname,
                UserGroupId = model.GroupId,
                Birth = model.Birth,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email
            };

            if (buttonType == "edit")
            {
                await _userService.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Permission(UserPermissionViewModel Model, string ButtonType)
        {
            IEnumerable<UserPermission> List = UserPermissionViewModel.To(Model);

            if (ButtonType == "permission")
            {
                await _userPermissionService.CreateOrUpdatePermissionsAsync(List);
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchModel(UserSearchViewModel model)
        {
            User user = new User
            {
                Username = model.Username
            };
            IEnumerable<User> list = _userService.Search(user);

            list = list;

            var newModel = list.Select(user => new UserIndexViewModel
            {
                Username = user.Username,
                Fullname = user.Fullname,
                GroupDisplay = user.UserGroup.Display,
                Birth = user.Birth,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email
            });
            return View("Index", newModel.ToList());
        }

        public UserIndexViewModel getFirstCheckedModel(IList<UserIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }

        public List<string> getCheckedIdList(IList<UserIndexViewModel> model)
        {
            List<string> list = new List<string>();
            foreach (UserIndexViewModel obj in model)
            {
                if (obj.Checked)
                {
                    list.Add(obj.Username);
                }
            }
            return list;
        }
    }
}
