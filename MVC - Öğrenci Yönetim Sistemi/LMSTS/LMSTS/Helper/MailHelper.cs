using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace LMSTS.Helper
{
    public class MailHelper
    {
        internal static bool SentMail(string toMail, string subject, string message)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("altinoranalvav2@gmail.com");
            mail.To.Add(toMail);
            mail.Subject = subject;
            mail.Body = message;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("altinoranalvav2@gmail.com", "alfav2qqey2C");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = mail;
            bool control = true;
            try
            {
                smtp.Send(mail);
            }
            catch (SmtpException)
            {
                control = false;
            }
            return control;
        }
    }
}