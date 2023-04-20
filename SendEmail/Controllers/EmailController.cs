using SendEmail.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SendEmail.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Email\


        [HttpGet]
        public ActionResult SendMail()
        {
            return View();
        }
        //HTTP POST METHOD

        [HttpPost]
        public ActionResult SendMail(EmailModel model)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;

                    NetworkCredential cred = new NetworkCredential(model.Email, model.Password);
                    smtp.Credentials = cred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.Message = "Email Sent";
                }
            }
            return View();
        }
    }
}