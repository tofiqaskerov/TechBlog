using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlog.ViewModels;

namespace TechBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: BlogController
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();

            var blog = _blogService.Detail(id);
            var popularBlogs = _blogService.GetPopularBlogs();
           
            BlogDetailVM detailVM = new()
            {
                Blog = blog,
                PopularBlogs = popularBlogs
            };
            return View(detailVM);
        }
       
    }
}
