using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebSite.Controllers
{
    public class AddPostController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewPost(BlogEntry newEntry)
        {
            db.BlogEntries.Add(newEntry);
            db.SaveChanges();
            return RedirectToAction("NewPost");
        }
    }
}
