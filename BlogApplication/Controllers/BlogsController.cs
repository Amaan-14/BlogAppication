using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;
using static System.Net.WebRequestMethods;

namespace BlogApplication.Controllers
{
    
    public class BlogsController : Controller
    {
        private DbBlogContext db = new DbBlogContext();
        SaveImage Image = SaveImage.CreateObject();

        private string ImageSaver(HttpPostedFileBase Photo)
        {
            if (Photo != null && Photo.ContentLength > 0)
            {
                string filename = "./../Images/" + Image.Save(Photo);
                return filename;
            }

            return " ";
        }

        // GET: Blogs
        [Authorize]
        public ActionResult Index(int? Page)
        {
            var blogs = db.blogs.Include(b => b.Categories);

            return View(blogs.ToList());
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "Name");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,CategoryId,Description1,Description2,Description3,Description4,Description5")] Blog blog, HttpPostedFileBase Photo1, HttpPostedFileBase Photo2, HttpPostedFileBase Photo3, HttpPostedFileBase Photo4, HttpPostedFileBase Photo5)
        {
            if (ModelState.IsValid)
            {

                blog.Photo1 = ImageSaver(Photo1);
                blog.Photo2 = ImageSaver(Photo2);
                blog.Photo3 = ImageSaver(Photo3);
                blog.Photo4 = ImageSaver(Photo4);
                blog.Photo5 = ImageSaver(Photo5);



                string[] descriptionProperties = { "Title", "Description1", "Description2", "Description3", "Description4", "Description5" };
                foreach (var prop in descriptionProperties)
                {
                    if (string.IsNullOrEmpty(blog.GetType().GetProperty(prop).GetValue(blog) as string))
                    {
                        blog.GetType().GetProperty(prop).SetValue(blog, " ");
                    }
                }


                db.blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }


        [HttpGet]
        [Authorize]
        public ActionResult ChangePhoto(int? id, int Photo)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var Blog = db.blogs.Find(id);
            TempData["ChangePhotoNumber"] = Photo;

            return View(Blog);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePhoto(HttpPostedFileBase Photo, int id)
        {
            int ChangePhotoNumber = Convert.ToInt32(TempData["ChangePhotoNumber"].ToString());

            var Blog = db.blogs.Find(id);


            switch (ChangePhotoNumber)
            {
                case 1:
                    if (Blog.Photo1 != null)
                    {
                        Image.Delete(Blog.Photo1);
                    }
                    Blog.Photo1 = ImageSaver(Photo);
                    break;
                case 2:
                    if (Blog.Photo2 != null)
                    {
                        Image.Delete(Blog.Photo2);
                    }
                    Blog.Photo2 = ImageSaver(Photo);
                    break;
                case 3:
                    if (Blog.Photo3 != null)
                    {
                        Image.Delete(Blog.Photo3);
                    }
                    Blog.Photo3 = ImageSaver(Photo);
                    break;
                case 4:
                    if (Blog.Photo4 != null)
                    {
                        Image.Delete(Blog.Photo4);
                    }
                    Blog.Photo4 = ImageSaver(Photo);
                    break;
                case 5:
                    if (Blog.Photo5 != null)
                    {
                        Image.Delete(Blog.Photo5);
                    }
                    Blog.Photo5 = ImageSaver(Photo);
                    break;
            }

            db.Entry(Blog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit", new { id });
        }


        // GET: Blogs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,Title,CategoryId,Description1,Description2,Description3,Description4,Description5")] Blog blog)
        {

            var Editblog = db.blogs.Find(blog.Id);
            Editblog.Title = blog.Title;
            Editblog.CategoryId = blog.CategoryId;
            Editblog.Description1 = blog.Description1;
            Editblog.Description2 = blog.Description2;
            Editblog.Description3 = blog.Description3;
            Editblog.Description4 = blog.Description4;
            Editblog.Description5 = blog.Description5;


            string[] descriptionProperties = { "Title", "Description1", "Description2", "Description3", "Description4", "Description5" };
            foreach (var prop in descriptionProperties)
            {
                if (string.IsNullOrEmpty(Editblog.GetType().GetProperty(prop).GetValue(Editblog) as string))
                {
                    Editblog.GetType().GetProperty(prop).SetValue(Editblog, " ");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(Editblog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Blog blog = db.blogs.Find(id);




        //    if (blog == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(blog);
        //}

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.blogs.Find(id);

            Image.Delete(blog.Photo1);
            Image.Delete(blog.Photo2);
            Image.Delete(blog.Photo3);
            Image.Delete(blog.Photo4);
            Image.Delete(blog.Photo5);

            db.blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
