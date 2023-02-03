using Microsoft.AspNetCore.Mvc;
using BlogWebSite.Models;
using BlogWebSite.Models.Context;

namespace BlogWebSite.Controllers
{
    public class PostController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        public IActionResult Index()
        {
            var response = db.BlogEntries.ToList();
            return View(response);
        }
    }
}
