using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UserRegistration.Interfaces;
using UserRegistration.Models;

namespace UserRegistration.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings Settings { get; private set; }

        protected EmailService() { }

        public EmailService(IOptions<EmailSettings> settings)
        {
            Settings = settings.Value;
        }

        public void Send(string subject, string content, string recipient)
        {
            // do nothing
        }

        public async Task SendAsync(string subject, string content, string recipient)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Settings.RegistrarEmail, Settings.RegistrarName)
                };

                mail.To.Add(new MailAddress(recipient));
                mail.Subject = subject;
                mail.Body = content;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(Settings.Domain, Settings.Port))
                {
                    smtp.Credentials = new NetworkCredential(Settings.RegistrarEmail, Settings.RegistrarPassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not send email. Reason: " + ex.Message);
            }
        }
    }
}
