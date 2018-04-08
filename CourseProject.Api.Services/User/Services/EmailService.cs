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

      emailMessage.From.Add(new MailboxAddress("Администрация сайта", "kor1997@mail.ru"));
      emailMessage.To.Add(new MailboxAddress("", email));
      emailMessage.Subject = subject;
      emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
      {
        Text = message
      };

      using (var client = new SmtpClient())
      {
        await client.ConnectAsync("smtp.mail.ru", 25, false);
        await client.AuthenticateAsync("kor1997@mail.ru", "fogolan7002621");
        await client.SendAsync(emailMessage);

        await client.DisconnectAsync(true);
      }
    }
  }
}