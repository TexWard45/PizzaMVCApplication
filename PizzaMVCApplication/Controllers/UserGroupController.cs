using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Entity;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Persistence;
using PizzaMVCApplication.Services;
using PizzaMVCApplication.Services.Implementation;
using System.Collections.Generic;

namespace PizzaMVCApplication.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly IUserGroupService _userGroupService;
        private readonly IUserGroupPermissionService _userGroupPermissionService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UserGroupController(IUserGroupService userGroupService, IUserGroupPermissionService userGroupPermissionService, IWebHostEnvironment hostingEnvironment)
        {
            _userGroupService = userGroupService;
            _hostingEnvironment = hostingEnvironment;
            _userGroupPermissionService = userGroupPermissionService;
        }

        public IActionResult Index()
        {
            var model = _userGroupService.GetAll().Select(group => new UserGroupIndexViewModel
            {
                GroupId = group.GroupId,
                Display = group.Display
            });
            return View(model.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IList<UserGroupIndexViewModel> model, string buttonType)
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserGroupIndexViewModel model)
        {
            UserGroup userGroup = new UserGroup
            {
                GroupId = model.GroupId,
                Display = model.Display
            };
            await _userGroupService.CreateAsync(userGroup);
            return RedirectToAction("Index");
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchModel(UserGroupSearchViewModel model)
        {
            UserGroup userGroup = new UserGroup
            {
                GroupId = model.GroupId,
                Display = model.Display
            };
            IEnumerable<UserGroup> list = _userGroupService.Search(userGroup);
            var newModel = list.Select(group => new UserGroupIndexViewModel
            {
                GroupId = group.GroupId,
                Display = group.Display
            });
            return View("Index", newModel.ToList());
        }

        public IActionResult Info()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Info(UserGroupInfoViewModel model)
        {
            UserGroup userGroup = new UserGroup
            {
                GroupId = model.GroupId,
                Display = model.Display
            };
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
        public async Task<IActionResult> Edit(UserGroupEditViewModel model, string buttonType)
        {
            UserGroup userGroup = new UserGroup
            {
                GroupId = model.GroupId,
                Display = model.Display
            };

            if (buttonType == "edit")
            {
                await _userGroupService.UpdateAsync(userGroup);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Permission(UserGroupPermissionViewModel Model, string ButtonType)
        {
            IEnumerable<UserGroupPermission> List = UserGroupPermissionViewModel.To(Model);

            if (ButtonType == "permission")
            {
                await _userGroupPermissionService.CreateOrUpdatePermissionsAsync(List);
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        [HttpGet]
        public IActionResult Edit(int GroupId)
        {
            var group = _userGroupService.GetById(GroupId);
            var model = new UserGroupEditViewModel()
            {
                GroupId = (int) group.GroupId,
                Display = group.Display
            };
            return View(model);
        }

        public IActionResult DirectToInfo(IList<UserGroupIndexViewModel> model)
        {
            UserGroupIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                UserGroupInfoViewModel infoModel = new UserGroupInfoViewModel
                {
                    GroupId = (int) obj.GroupId,
                    Display = obj.Display
                };
                return View("Info", infoModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToEdit(IList<UserGroupIndexViewModel> model)
        {
            UserGroupIndexViewModel obj = getFirstCheckedModel(model);
            
            if (obj != null) {
                UserGroupEditViewModel editModel = new UserGroupEditViewModel
                {
                    GroupId = (int) obj.GroupId,
                    Display = obj.Display
                };
                return View("Edit", editModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DirectToPermission(IList<UserGroupIndexViewModel> model)
        {
            UserGroupIndexViewModel obj = getFirstCheckedModel(model);

            if (obj != null)
            {
                int GroupId = (int) obj.GroupId;
                string GroupDisplay = _userGroupService.GetById(GroupId).Display;
                IEnumerable<UserGroupPermission> groupPermissionList = _userGroupPermissionService.GetPermissionsByGroupId(GroupId);

                UserGroupPermissionViewModel permissionModel = UserGroupPermissionViewModel.From(GroupId, groupPermissionList);
                permissionModel.GroupDisplay = GroupDisplay;
                return View("Permission", permissionModel);
            }

            return RedirectToAction("Index");
        }

        public UserGroupIndexViewModel getFirstCheckedModel(IList<UserGroupIndexViewModel> model)
        {
            return model.Where(e => e.Checked).FirstOrDefault();
        }

        public async Task Delete(IList<UserGroupIndexViewModel> model)
        {
            List<int> list = getCheckedIdList(model);

            await _userGroupService.DeleteAsync(list);
        }

        public List<int> getCheckedIdList(IList<UserGroupIndexViewModel> model)
        {
            List<int> list = new List<int>();
            foreach (UserGroupIndexViewModel obj in model)
            {
                if (obj.Checked)
                {
                    list.Add((int) obj.GroupId);
                }
            }
            return list;
        }
    }
}
