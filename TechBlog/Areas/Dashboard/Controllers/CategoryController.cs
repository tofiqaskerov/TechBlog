
using Business.Abstract;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
               var categories = _categoryService.GetAll();
               return View(categories);
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }  
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {

            try
            {

                var selectedCategory = _categoryService.GetByName(category.Name);   
                if(category.Name != null   )
                {
                    if(selectedCategory == null)
                    {
                        _categoryService.Add(category);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("Name", "Cannot have a category with the same name");
                        return View(category);
                    }
                }
                else
                {
                    ModelState.AddModelError("Name", "Don't send empty");
                    return View(category);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                _categoryService.Delete(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
