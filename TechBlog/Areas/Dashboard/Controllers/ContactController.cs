using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize( Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetAll();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            
            var contact = _contactService.GetById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var contact = _contactService.GetById(id);
                _contactService.Delete(contact);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
