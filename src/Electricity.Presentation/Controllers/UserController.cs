using Electricity.BusinessLogic.Services.Interface;
using Electricity.DataAccess.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
