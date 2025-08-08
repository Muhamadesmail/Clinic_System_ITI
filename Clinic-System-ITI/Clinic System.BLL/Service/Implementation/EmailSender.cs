using Clinic_System.BLL.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Clinic_System.BLL.Service.Abstraction
namespace Clinic_System.BLL.Service.Implementation
{
    public class EmailSender : IEmailSender
    {

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("eldeeba124@gmail.com", "domuzbihypdgbgpp"), // Use an app-specific password
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("eldeeba124@gmail.com","Royal clinic Hospital"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }

}
