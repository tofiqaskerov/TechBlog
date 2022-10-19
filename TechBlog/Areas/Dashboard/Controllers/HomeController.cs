using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
