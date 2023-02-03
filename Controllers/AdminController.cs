using Microsoft.AspNetCore.Mvc;

namespace BlogWebSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
