using RDKHomeSolutions.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RDKHomeSolutions.Website2.Models;
using RDKHomeSolutions2.Website;


namespace RDKHomeSolutions.Website2.Controllers
{
    public class NewsLetterController : BaseController
    {
        private readonly INewsLetterService newsLetterService;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(NewsLetterController));

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            this.newsLetterService = newsLetterService ?? throw new ArgumentNullException(nameof(newsLetterService));
        }

        [HttpPost]
        public async Task<ActionResult> Subscribe(NewsLetterSubscribeModel newsLetterSubscribeModel)
        {
            var resultModel = new ResultModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultModel.Result = false;
                    resultModel.Message = "Please submit a valid email address";
                    return Json(resultModel);
                }

                var resultTuple = await newsLetterService.Subscribe(newsLetterSubscribeModel.Email);
                resultModel.Result = resultTuple.result;
                resultModel.Message = resultTuple.message;

                MailMessage message = new MailMessage(SiteSettings.EmailFrom, SiteSettings.EmailTo);
                message.Subject = "New Email Subscription to News Letter";
                message.Body = $"Email: {newsLetterSubscribeModel.Email} subscribed to the news letter.";

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
            }
            catch (Exception e)
            {
                resultModel.Result = false;
                resultModel.Message = "An error occurred please contact info@rdkhomesolutions.com";
                Log.Error(e);
            }
            return Json(resultModel);
        }
    }
}