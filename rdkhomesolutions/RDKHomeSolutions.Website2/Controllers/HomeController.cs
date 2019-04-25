using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using RDKHomeSolutions.Website2.Models;
using RDKHomeSolutions2.Website;

namespace RDKHomeSolutions.Website2.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateGoogleCaptcha]
        public ActionResult Contact(ContactModel contactModel)
        {
            if (!ModelState.IsValid)
            {
                return View(contactModel);
            }

            MailMessage message = new MailMessage(SiteSettings.EmailFrom, SiteSettings.EmailTo);
            message.Subject = "New Feedback From RDK Home Solutions Website";
            message.Body = $"Name: {contactModel.FirstName} {contactModel.LastName} \n" +
                           $"Email: {contactModel.Email} \n" +
                           $"Comment: {HttpUtility.HtmlEncode(contactModel.Comment)}";
            SmtpClient client = new SmtpClient(SiteSettings.MailServer)
            {
                Port = 587,
                EnableSsl = true,
            };

            client.Credentials = new NetworkCredential(SiteSettings.GmailUsername, SiteSettings.GmailPassword);
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }

            return View("Success");
        }
    }
}