
using Electricity.BusinessLogic.Requests;
using Electricity.BusinessLogic.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Electricity.Presentation.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
       

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserRequest userLogin)
        {
            var user_ = await _userService.LoginAsync(userLogin.Username, userLogin.Password);
            if (user_ != null) 
            {
                await _userService.AuthenticateAsync(HttpContext, userLogin.Username, user_.Role.Name);

                return RedirectToAction("Index","Renter");
            }
            return Forbid();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister user)
        {
            if(user.Password == user.ConfirmPassword)
            {
                await _userService.AddAsync(user);
            }
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
