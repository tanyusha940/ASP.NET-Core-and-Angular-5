using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace CourseProject.Api.Services.User.Services
{
  public class EmailService : IEmailService
  {
    public async Task SendEmailAsync(string email, string subject, string message)
    {
      var emailMessage = new MimeMessage();

      emailMessage.From.Add(new MailboxAddress("Администрация сайта", "tatsiana.shkoda@gmail.com"));
      emailMessage.To.Add(new MailboxAddress("", email));
      emailMessage.Subject = subject;
      emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
      {
        Text = message
      };

      using (var client = new SmtpClient())
      {
        await client.ConnectAsync("smtp.gmail.com", 465, true);
        await client.AuthenticateAsync("tatsiana.shkoda@gmail.com", "1281velcom");
        await client.SendAsync(emailMessage);

        await client.DisconnectAsync(true);
      }
    }
  }
}