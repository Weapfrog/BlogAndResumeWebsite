using BlogWebSite.Models;
using BlogWebSite.Models.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogWebSite.Controllers
{
    public class LoginController : Controller
    {
        BlogWebsiteContext db = new BlogWebsiteContext();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var response = db.Users.FirstOrDefault(x => x.eMail == email && x.Password == password);
                if (response == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,response.eMail)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "a");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                    
                }

            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> LogOut(string username)
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
                );
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Signin(User newUser)
        {
            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }

    }
}
