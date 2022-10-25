using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlog.ViewModels;

namespace TechBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
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
            var nextBlog = _blogService.GetNextBlog(id);
            var prevBlog = _blogService.GetPrevBlog(id);
            var categories = _categoryService.GetAll();

            BlogDetailVM detailVM = new()
            {
                Blog = blog,
                PopularBlogs = popularBlogs,
                NextBlog = nextBlog,
                PrevBlog = prevBlog,
                Categories = categories
            };
            return View(detailVM);
        }
       
    }
}
