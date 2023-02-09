using Microsoft.AspNetCore.Mvc;
using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;


namespace BlogWebSite.Controllers
{

    public class PostController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                var response = (from user in db.Users where user.eMail == email select user).FirstOrDefault();
                ViewBag.Username = response.Username;
            }
            List<CommentProcedure> responseComment = new List<CommentProcedure>();
            var responsePost = (from post in db.BlogEntries
                                join user in db.Users on post.UserID equals user.UserID
                                select new Procedure
                                {
                                    BlogPost = post.BlogPost,
                                    BlogTitle = post.BlogTitle,
                                    PostID = post.BlogEntryID,
                                    Time = post.Time,
                                    UserID = post.UserID,
                                    Username = user.Username,
                                    Likes = post.Likes,
                                    Dislikes = post.Dislikes,
                                    PostImage = post.PostImage

                                }).ToList();


            return View(responsePost);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPost(int? id)
        {
            var email = User.Identity.Name;
            if (email != null)
            {
                var response = (from user in db.Users where user.eMail == email select user).FirstOrDefault();
                ViewBag.Username = response.Username;
            }

            List<Comment> comments = new List<Comment>();
            if (id == null)
            {
                return BadRequest();
            }


            var post = (from entry in db.BlogEntries
                        join user in db.Users on entry.UserID equals user.UserID
                        where entry.BlogEntryID == id
                        select new Procedure
                        {
                            BlogPost = entry.BlogPost,
                            BlogTitle = entry.BlogTitle,
                            PostID = entry.BlogEntryID,
                            UserID = entry.UserID,
                            Time = entry.Time,
                            Username = user.Username,
                            Likes = entry.Likes,
                            Dislikes = entry.Dislikes,
                            PostImage = entry.PostImage
                        }).FirstOrDefault();

            if (post == null)
            {
                return NotFound();
            }
            var len = db.Comments.Where(a => a.PostID == post.PostID).ToList().Count;
            for (int i = 0; i < len; i++)
            {
                comments.Add(db.Comments.Where(a => a.PostID == post.PostID).ToList()[i]);
            }
            var query = (from comment in db.Comments
                         join user in db.Users on comment.UserID equals user.UserID
                         where comment.PostID == id
                         select new CommentProcedure
                         {
                             PostID = comment.PostID,
                             CommentID = comment.CommentID,
                             CommentText = comment.CommentText,
                             Time = comment.Time,
                             UserID = comment.UserID,
                             Username = user.Username,
                             Likes = comment.Likes,
                             Dislikes = comment.Dislikes
                         }).ToList();
            ViewData["Post"] = post;
            ViewData["ShowComments"] = query;

            return View();
        }
        [HttpPost]
        public IActionResult GetPost(Comment newComment)
        {
            var email = User.Identity.Name;
            var currentUser = (from user in db.Users where user.eMail == email select user).FirstOrDefault();
            newComment.Time = DateTime.Now;
            newComment.UserID = currentUser.UserID;
            db.Comments.Add(newComment);
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = newComment.PostID });
        }
        public IActionResult IncrementLike(int? id)
        {
            var response = db.Comments.Find(id);
            response.Likes += 1;
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = response.PostID });
        }
        public IActionResult IncrementDislike(int? id)
        {
            var response = db.Comments.Find(id);
            response.Dislikes += 1;
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = response.PostID });
        }
        [HttpGet]
        public IActionResult EditPost(int postID)
        {
            var response = db.BlogEntries.Find(postID);

            return View(response);
        }
        [HttpPost]
        public IActionResult EditPost(BlogEntry edittedEntry)
        {
            var response = db.BlogEntries.Find(edittedEntry.BlogEntryID);
            response.BlogPost = edittedEntry.BlogPost;
            response.BlogTitle = edittedEntry.BlogTitle;
            db.SaveChanges();

            return RedirectToAction("GetPost", new { id = response.BlogEntryID });
        }
        public IActionResult DeletePost(int? id)
        {
            var responsePost = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(responsePost);
            var responseComment = (from comment in db.Comments where comment.PostID == responsePost.BlogEntryID select comment).ToList();
            foreach (var item in responseComment)
            {
                db.Comments.Remove(item);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditComment(int? id)
        {
            var responseComment = db.Comments.Find(id);

            return View(responseComment);
        }
        [HttpPost]
        public IActionResult EditComment(Comment edittedComment)
        {
            var response = db.Comments.Find(edittedComment.CommentID);
            response.CommentText = edittedComment.CommentText;
            db.SaveChanges();

            return RedirectToAction("GetPost", new { id = edittedComment.PostID });
        }
        public IActionResult DeleteComment(int? commentID)
        {
            var responseComment = db.Comments.Find(commentID);
            db.Comments.Remove(responseComment);
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = responseComment.PostID });
        }

        public IActionResult LikePost(int? id)
        {
            var response = db.BlogEntries.Find(id);
            response.Likes += 1;
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = id });
        }
        public IActionResult DislikePost(int? id)
        {
            var response = db.BlogEntries.Find(id);
            response.Dislikes += 1;
            db.SaveChanges();
            return RedirectToAction("GetPost", new { id = id });
        }
    }
}
