using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebSite.Controllers
{
    public class ProfileController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        [HttpGet]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var response = (from user in db.Users where user.eMail == userMail select user).FirstOrDefault();
            ViewBag.Username = response.Username;   
            return View(response);
        }
        [HttpPost]
        public IActionResult Index(AddProfilePic user)
        {
            var response = db.Users.Find(user.UserID);
            if (user.UserPicture != null)
            {
                var extension = Path.GetExtension(user.UserPicture.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                user.UserPicture.CopyTo(stream);
                response.UserPicture = newImageName;
            }
            response.Username = user.Username;
            response.NameSurname = user.NameSurname;
            response.About = user.About;
            if(user.Password!= null)
                response.Password = user.Password;
            response.age = user.age;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
