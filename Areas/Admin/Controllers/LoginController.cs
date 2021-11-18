using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using comestic_csharp.Models;
using comestic_csharp.Security;
using Org.BouncyCastle.Crypto.Generators;

namespace comestic_csharp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Login")]
    public class LoginController : Controller
    {
        private ShopContext db = new ShopContext();

        private SecurityManager securityManager = new SecurityManager();

        public LoginController(ShopContext _db){
            _db = db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string email, string password){
            var user = processLogin (email,password);
            if ( user != null){
                securityManager.SignIn(this.HttpContext, user);
                return RedirectToAction("index","Dashboard", new { area = "Admin"});

            } else {
                ViewBag.error = "Invalid User";
                return View("Index");
            }
        }

        private User processLogin(string email, string password){
            var user = db.Users.SingleOrDefault( u => u.Email == email);
            if ( user != null){
                if (password == user.Password){
                    return user;
                }
            }
            return null;
        }


        [Route("signout")]
        public IActionResult SignOut(){
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("index","Login", new { area = "admin"});
        }


        [Route("accessdenied")]
        public IActionResult AccessDenied(){
            return View();
        }


    }
}