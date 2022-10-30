using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechBlog.ViewModels;

namespace TechBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogCommentService _blogCommentService;

        public BlogController(IBlogService blogService, ICategoryService categoryService, IBlogCommentService blogCommentService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _blogCommentService = blogCommentService;
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
                Categories = categories,

            };
            return View(detailVM);
        }

        //[HttpPost]
        //public async Task<IActionResult> Comment(Comment comment,  int id)
        //{
        //    _blogService.UpdateById(id);
        //    BlogComment blogComment = new()
        //    {
        //        CommentId = comment.Id,
        //        BlogId = id
        //    };
        //    _blogCommentService.Add(blogComment);
        //    return Ok();
        //}


    }
}
