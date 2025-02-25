using System;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
namespace CasaMiro.frontend.Components;

public class EmailService
{
    private readonly string smtpServer = "smtp.gmail.com"; // Change if using another provider
    private readonly int smtpPort = 587; // 465 for SSL
    private readonly string smtpUser = "your-email@gmail.com";
    private readonly string smtpPass = "your-app-password"; // Use App Password for Gmail

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Casa Miro", smtpUser));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = subject;
        message.Body = new TextPart("html") { Text = body };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(smtpUser, smtpPass);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
