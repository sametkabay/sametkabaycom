using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SametKabay.Application.Helpers
{
    public static class SendMailHelper
    {
        public static async Task SendMail(string body)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
               UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sametkabayweb@gmail.com", "Sametkabay123")
            };

            using (var message = new MailMessage("sametkabayweb@gmail.com", "smtkby@gmail.com")
            {
                Subject = "WebSite",
                Body = body
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
