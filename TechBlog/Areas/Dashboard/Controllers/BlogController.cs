using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("dashboard")]

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlogService blogService, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
        }

        // GET: BlogController
        public IActionResult Index()
        {
            var blogs = _blogService.GetAllBlogIncludeCategory();
            return View(blogs);
        }

        // GET: BlogController/Details/5
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == null) return NotFound();
            var blog = _blogService.GetBlogIncludeCategory(id);
            if (blog == null) return NotFound();
            return View(blog);
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewData["Categories"] = categories;
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog, IFormFile NewPhotoURL)
        {


                string path = "/main/img/" + Guid.NewGuid() + NewPhotoURL.FileName;
                using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                {
                    NewPhotoURL.CopyTo(fileStream);
                }
                try
                {
                    blog.PhotoURl = path;
                    _blogService.Add(blog);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            
          
        }

        // GET: BlogController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blog = _blogService.GetById(id);
            var categories = _categoryService.GetAll();
            ViewData["Categories"] = categories;
            return View(blog);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        public IActionResult Edit(Blog blog, IFormFile NewPhotoURL, string? oldPhoto)
        {
            try
            {

                if (NewPhotoURL != null)
                {
                    string path = "/main/img/" + Guid.NewGuid() + NewPhotoURL.FileName;
                    using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        NewPhotoURL.CopyTo(fileStream);
                    }
                    blog.PhotoURl = path;

                }
                else blog.PhotoURl = oldPhoto;

                _blogService.Update(blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: BlogController/Delete/5


        // POST: BlogController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var blog = _blogService.GetById(id);
                _blogService.Delete(blog);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
