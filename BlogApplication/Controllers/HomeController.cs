using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult SendEmail()
        {
            var Name = Request.Form["name"];
            var Phone = Request.Form["number"];
            var Email = Request.Form["email"];
            var Message = Request.Form["message"];

            if (!IsValidEmail(Email))
            {
                return Content("Invalid Email");
            }

            var Subject = "New Contact Form Submission";
            var Body = $"Name: {Name}\nPhone No: {Phone}\nEmail: {Email}\nMessage:\n{Message}";

            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new NetworkCredential("hackerson1492001@gmail.com", "sbcclncayoplxnml");

                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(Email);
                mailMessage.To.Add(new MailAddress("hackerson1492001@gmail.com"));
                mailMessage.Subject = Subject;
                mailMessage.Body = Body;

                smtpClient.Send(mailMessage);
            }

            return Json(new { success = true, message = "Form Submitted Successfully" });

        }
    }
}