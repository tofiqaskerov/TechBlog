using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechBlog.Models;

namespace TechBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService _blogService;
        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogs = _blogService.GetAllBlogIncludeCategory();
            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}