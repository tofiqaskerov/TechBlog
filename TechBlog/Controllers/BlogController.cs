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
        
        public IActionResult Detail(int id)
        {
            var blog = _blogService.GetBlogIncludeCategory(id);
            BlogDetailVM detailVM = new()
            {
                Blog = blog
            };
            return View(detailVM);
        }
       
    }
}
