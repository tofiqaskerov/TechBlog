using Business.Abstract;
using Core.Entity.Models;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
      

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register, IFormFile NewPhotoURL)
        {
            var user = await _userManager.FindByEmailAsync(register.Email);
            if (user != null)
                return View();
            string path = "/main/img/" + Guid.NewGuid() + NewPhotoURL.FileName;
            using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                NewPhotoURL.CopyTo(fileStream);
            }
            try
            {
                User newUser = new()
                {
                    UserName = register.Email,
                    Name = register.Name,
                    Surname = register.Surname,
                    Email = register.Email,
                    PhotoURL = path,
                    AboutAuthor = "Quisque sed tristique felis. Lorem visit my website amet, consectetur adipiscing elit. Phasellus quis mi auctor, tincidunt nisl eget, finibus odio. Duis tempus elit quis risus congue feugiat. Thanks for stop Tech Blog!"
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);

                if (result.Succeeded) return RedirectToAction("Login");

                return View();

            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if(user == null) return View();

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.Succeeded) return RedirectToAction("Index", "Home");

            return View();
        }

    }
}
