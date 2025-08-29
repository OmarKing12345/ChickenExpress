 using Microsoft.AspNetCore.Identity;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Net;
 using System.Net.Mail;
 using System.Text;
 using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ChickenExpress.Infrastructure.Services
 {
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("abdullahzaghloul022@gmail.com", "xwxa odtd muyr lchg")
            };

            return client.SendMailAsync(
            new MailMessage(from: "abdullahzaghloul022@gmail.com",
                            to: email,
                            subject,
                            htmlMessage
                            )
            {
                IsBodyHtml = true
            });
        }
    }
}
