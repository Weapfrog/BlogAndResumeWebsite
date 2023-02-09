using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;


namespace BlogWebSite.Controllers
{
    public class AddPostController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        [Authorize]
        [HttpGet]
        public IActionResult NewPost()
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                var response = (from user in db.Users where user.eMail == email select user).FirstOrDefault();
                ViewBag.Username = response.Username;
            }
            return View();
        }

        [HttpPost]
        public IActionResult NewPost(AddPostPic newEntry)
        {
            BlogEntry newPost = new BlogEntry();
            var email = User.Identity.Name;
            var response = (from user in db.Users where user.eMail == email select user).FirstOrDefault();
            if(newEntry.PostImage!= null)
            {
                var extension = Path.GetExtension(newEntry.PostImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                newEntry.PostImage.CopyTo(stream);
                newPost.PostImage = newImageName;
            }
            newEntry.UserID = response.UserID;
            newPost.UserID = newEntry.UserID;
            newPost.BlogTitle = newEntry.BlogTitle;
            newPost.BlogPost = newEntry.BlogPost;
            db.BlogEntries.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("Index","Post");
        }
    }
}
