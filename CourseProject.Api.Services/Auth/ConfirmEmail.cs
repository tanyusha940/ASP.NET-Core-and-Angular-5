using System.Threading.Tasks;
using CourseProject.Data.Model;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Api.Services.Auth
{
  public class ConfirmEmail
  {
    public class Query : IRequest<bool>
    {
      public string UserId { get; set; }

      public string Code { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, bool>
    {
      private readonly UserManager<UserIdentity> userManager;

      public Handler(UserManager<UserIdentity> userManager)
      {
        this.userManager = userManager;
      }

      protected async override Task<bool> HandleCore(Query request)
      {
        var user = await userManager.FindByIdAsync(request.UserId);
        var result = await userManager.ConfirmEmailAsync(user, request.Code);
        return result.Succeeded;
      }
    }
  }
}