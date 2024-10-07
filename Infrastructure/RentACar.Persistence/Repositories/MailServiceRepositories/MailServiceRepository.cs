using RentACar.Application.Interfaces.MailServiceInterfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.MailServiceRepositories
{
    public class MailServiceRepository : IMailServiceRepository
    {
        private readonly string _smtpServer = "sandbox.smtp.mailtrap.io"; 
        private readonly int _smtpPort = 2525; 
        private readonly string _smtpUser = "0316aadeda319b"; 
        private readonly string _smtpPassword = "e768dbe433e746"; 
        public void SendReservationApprovalEmail(string toEmail, string name)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CarBook", _smtpUser));
            message.To.Add(new MailboxAddress(name, toEmail));
            message.Subject = "Rezervasyon Onaylandı";

            message.Body = new TextPart("plain")
            {
                Text = $"Merhaba {name},\n\nRezervasyonunuz onaylandı. Teşekkür ederiz!\n\nİyi günler dileriz."
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    
                    client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(_smtpUser, _smtpPassword);
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
