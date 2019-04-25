using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RDKHomeSolutions2.Website
{
    public static class SiteSettings
    {
        public static readonly string GoogleRecaptchaSecretKey = ConfigurationManager.AppSettings["googleRecaptchaSecretKey"];

        public static readonly string GoogleRecaptchaSiteKey = ConfigurationManager.AppSettings["googleRecaptchaSiteKey"];

        public static readonly string EmailFrom = ConfigurationManager.AppSettings["email:from"];

        public static readonly string EmailTo = ConfigurationManager.AppSettings["email:to"];

        public static readonly string GmailUsername = ConfigurationManager.AppSettings["gmail:username"];

        public static readonly string GmailPassword = ConfigurationManager.AppSettings["gmail:password"];

        public static readonly string MailServer = ConfigurationManager.AppSettings["mailServer"];

        public static readonly string CaptchaPostUrl = ConfigurationManager.AppSettings["captchaPostUrl"];
    }
}