using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechBlog.Models;
using TechBlog.ViewModels;

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
            var popularBlogs = _blogService.GetPopularBlogs();
            var lastThreeBlog = _blogService.GetLastThreeBlog();
            var blogs = _blogService.GetAllBlogIncludeCategory();
            HomeVM vm = new()
            {
                LastBlogs = lastThreeBlog,
                Blogs = blogs,
                PopularBlogs = popularBlogs
            };
            return View(vm);
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