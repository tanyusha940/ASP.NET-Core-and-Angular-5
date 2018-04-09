using System.Threading.Tasks;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.AdminPanel
{
  public class IsUserAdmin
  {
    public class Query : IRequest<bool>
    {
      public string userId { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, bool>
    {
      private readonly UserManager<UserIdentity> userManager;

      public Handler(UserManager<UserIdentity> userManager)
      {
        this.userManager = userManager;
      }

      protected override async Task<bool> HandleCore(Query query)
      {
        var user = await userManager.FindByIdAsync(query.userId);
        return await isAdmin(user);
      }

      private async Task<bool> isAdmin(UserIdentity userIdentity)
      {
        var roles = await userManager.GetRolesAsync(userIdentity);
        var result = roles.Contains("admin");
        return result;
      }
    }
  }
}