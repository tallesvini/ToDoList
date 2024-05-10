using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs;
using TodoList.Application.Interfaces;

namespace TodoList.WebUI.Controllers
{
    public class AuthControlller : Controller
    {
        private readonly IUserService _userService;

        public AuthControlller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDTO userDto)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserDTO userDto)
        {
            return View();
        }
    }
}
