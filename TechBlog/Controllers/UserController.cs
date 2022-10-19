using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            var token = "test";
            token = _authService.Login(login);
            CookieOptions option = new();
            option.Expires = DateTime.UtcNow.AddMinutes(1);
            Response.Cookies.Append("token", token, option);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterDTO register)
        {
            try
            {
                _authService.Register(register);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
