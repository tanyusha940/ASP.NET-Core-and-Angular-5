using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Data.Model;

namespace CourseProject.Infrastructure.Authentication
{
  public interface IUserService
  {
    Task<UserIdentity> GetUserIdentity(ClaimsPrincipal userClaims);
  }
}