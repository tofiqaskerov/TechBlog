
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
                ViewBag.Categories = categories.Count();
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
            var category = _categoryService.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                var selectedCategory = _categoryService.GetByName(category.Name);
                if(selectedCategory != null && category.Id != selectedCategory.Id)
                {
                    ModelState.AddModelError("Name", "Cannot have a category with the same name");
                    return View(category);
                }

                _categoryService.Update(category);
                return RedirectToAction("Index");

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
