using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Infrastructure.Authentication
{
  public class UserSerivce: IUserService
  {
    private readonly UserManager<UserIdentity> userManager;

    public UserSerivce(UserManager<UserIdentity> userManager)
    {
      this.userManager = userManager;
    }

    public async Task<UserIdentity> GetUserIdentity(ClaimsPrincipal userClaims)
    {
      var userName = userClaims.Identities
        .First()
        .Claims.First().Value;
      var userIdentity = await userManager.FindByNameAsync(userName);

      return userIdentity;
    }
  }
}