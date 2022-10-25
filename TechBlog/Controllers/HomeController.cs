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
        private readonly ICategoryService _categoryService;
        public HomeController(ILogger<HomeController> logger, IBlogService blogService, ICategoryService categoryService)
        {
            _logger = logger;
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var popularBlogs = _blogService.GetPopularBlogs();
            var lastThreeBlog = _blogService.GetLastThreeBlog();
            var blogs = _blogService.GetAllBlogIncludeCategory();

            var categories = _categoryService.GetAll();
            HomeVM vm = new()
            {
                LastBlogs = lastThreeBlog,
                Blogs = blogs,
                PopularBlogs = popularBlogs,
                Categories = categories
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