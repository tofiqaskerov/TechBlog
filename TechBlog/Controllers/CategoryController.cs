using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using TechBlog.ViewModels;

namespace TechBlog.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public CategoryController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var blogs = _blogService.GetByCategoryIdIncludeCategory(id);
            var category = _categoryService.GetById(id);
            var popularBlogs = _blogService.GetPopularBlogs();
            var categories = _categoryService.GetAll();
            CategoryDetailVM detailVM = new()
            {
                Blogs = blogs,
                PopularBlogs = popularBlogs,
                Categories = categories,
                Category = category
            };
            return View(detailVM);
         
        }

        
        
    }
}
