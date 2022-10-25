using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();
            return View(role);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {

            if (!ModelState.IsValid) return View(role);
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) return RedirectToAction("Index");
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
               

                var role = await _roleManager.FindByIdAsync(id);
                if (role == null) return NotFound();

                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                    return RedirectToAction("Index");

                return View();
                
            }
            catch (Exception)
            {
                return View();
            }

        }

    }
}
