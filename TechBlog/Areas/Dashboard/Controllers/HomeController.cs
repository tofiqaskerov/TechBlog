using Microsoft.AspNetCore.Mvc;

namespace TechBlog.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
