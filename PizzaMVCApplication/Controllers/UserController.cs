using Microsoft.AspNetCore.Mvc;
using PizzaMVCApplication.Models;
using PizzaMVCApplication.Services;

namespace PizzaMVCApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UserController(IUserService userService, IWebHostEnvironment hostingEnvironment)
        {
            _userService = userService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index() { 
            var model = _userService.GetAll().Select(user => new UserIndexViewModel { 
                Username = user.Username,
                Fullname = user.Fullname,
                GroupDisplay = user.UserGroup.Display,
            });
            return View(model);
        }
    }
}
