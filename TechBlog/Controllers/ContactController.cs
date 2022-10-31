
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IContactService _contactService;

        public ContactController(ICategoryService categoryService, IContactService contactService)
        {
            _categoryService = categoryService;
            _contactService = contactService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> ContactMessage(Contact contact)
        {
                
             _contactService.AddAsync(contact);
            return Ok();
        }
    }
}
