using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    public class AdminController : Controller
    {
        private DbBlogContext db = new DbBlogContext();
        public ActionResult Dashboard()
            {
            ViewBag.BlogCount = db.blogs.Count();
            ViewBag.UserCount = db.users.Count();

                return View();
            }
        }
}