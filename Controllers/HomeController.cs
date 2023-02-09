using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BlogWebsiteContext db = new BlogWebsiteContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            if(email != null)
            {
                var response = (from user in db.Users where user.eMail == email select user.Username).FirstOrDefault();
                ViewBag.Username = response;
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Posts() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}