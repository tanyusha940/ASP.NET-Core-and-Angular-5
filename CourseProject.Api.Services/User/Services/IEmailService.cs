using System.Threading.Tasks;

namespace CourseProject.Api.Services.User.Services
{
  public interface IEmailService
  {
    Task SendEmailAsync(string email, string subject, string message);
  }
}