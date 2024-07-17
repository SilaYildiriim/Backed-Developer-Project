using Backed_Developer_Project.Application.Model.UserDtos;
using Backed_Developer_Project.Application.Services.UserService;
using Backed_Developer_Project.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backed_Developer_Project.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("GetAllForm", "Form");

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(loginDto);

                if (result.Succeeded)
                {
                    TempData["Success"] = "Login successful.";
                    return RedirectToAction("GetAllForm", "Form");
                }
            }

            TempData["Error"] = "Login failed.";
            return View(loginDto);
        }


        public async Task<IActionResult> Logout()
        {
            await _userService.LogOut();
            TempData["Success"] = "Successfully Logout";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
