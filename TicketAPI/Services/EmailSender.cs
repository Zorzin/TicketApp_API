using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendAsync(Email email)
        {
            try
            {
                SmtpClient client = new SmtpClient("SMTPSERVER");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("username", "password");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("mail@domain.com");
                mailMessage.To.Add(email.Recipient);
                mailMessage.Body = email.Body;
                mailMessage.Subject = email.Subject;
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public interface IEmailSender
    {
        Task SendAsync(Email email);
    }
}
