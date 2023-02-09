using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebSite.Controllers
{
    public class SearchPostController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var mail = User.Identity.Name;
            var response = (from user in db.Users where user.eMail == mail select user.Username).FirstOrDefault();
            ViewBag.Username = response;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Procedure postName)
        {
            List<Procedure> relatedPosts = new List<Procedure>();
            var response = db.BlogEntries.Where(x => x.BlogTitle.Contains(postName.BlogTitle)).ToList();
            foreach (var item in response)
            {
                Procedure relatedPost = new Procedure()
                {
                    PostID = item.BlogEntryID,
                    BlogPost = item.BlogPost,
                    BlogTitle = item.BlogTitle,
                    PostImage = item.PostImage,
                    Dislikes = item.Dislikes,
                    Likes = item.Likes,
                    Time = item.Time,
                    UserID = item.UserID
                };
                relatedPosts.Add(relatedPost);
            }
            ViewData["RelatedPosts"] = relatedPosts;
            return View();
        }
        public IActionResult RelatedPosts(List<Procedure> Posts)
        {
            return View(Posts);
        }
    }
}
