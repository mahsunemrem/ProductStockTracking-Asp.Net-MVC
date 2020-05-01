using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.Core.Utilities.Business
{
    public class SMTP
    {
        public static void SendEmailForgotPassword(string email,string username,string url)
        {
            Random R = new Random();

            var message = new MailMessage();
            message.To.Add(new MailAddress(email)); // mailin gideceği hesap
            message.From = new MailAddress("productstockdeneme@gmail.com");  // Mail gönderecek hasap
            message.Subject = "Your email subject";
            message.Body = "<p><h1>Product Stock Tracking</h1><strong>Dear :" + username + "</strong><br><br>" +
                "<div><p>Thank you for confirming  your email.Please <a href=" + url + ">Click here to Log in</a></div>" + "<p>Reference Code :E" + R.Next(888888, 9999999) + "</p> ";


            message.IsBodyHtml = true;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();

            NetworkCredential credential = new NetworkCredential("productstockdeneme@gmail.com", "psdeneme1"); // mail gönderecek hesap , şifre

            smtp.UseDefaultCredentials = true;
            smtp.Credentials = credential;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
    }
}
