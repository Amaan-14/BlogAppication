using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogApplication.Controllers
{
    public class AccountController : Controller
    {
        private DbBlogContext db = new DbBlogContext();
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User Usermodel)
        {
            bool CredentialIsValid = db.users.Any(x => x.Username == Usermodel.Username && x.Password == Usermodel.Password);

            if (CredentialIsValid)
            {
                FormsAuthentication.SetAuthCookie(Usermodel.Username, false);
                return Json(new { success = true, redirectUrl = Url.Action("Dashboard", "Admin") });
            }

            ModelState.AddModelError(" ", "Invalid username and password");

           return Json(new { success = false });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}