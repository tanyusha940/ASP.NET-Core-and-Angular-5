using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Api.Services.AdminPanel
{
  public class UpgradeToAdmin
  {
    public class Command : IRequest<bool>
    {
      public string UserId { get; set; }
    }

    public class Handler : AsyncRequestHandler<Command, bool>
    {
      private readonly ApplicationContext _context;
      private readonly UserManager<UserIdentity> userManager;

      public Handler(ApplicationContext context, UserManager<UserIdentity> userManager)
      {
        _context = context;
        this.userManager = userManager;
      }

      protected override async Task<bool> HandleCore(Command command)
      {
        var userToUpgrade = await userManager.FindByIdAsync(command.UserId);

        var userRoles = await userManager.GetRolesAsync(userToUpgrade);
        if (userRoles.Contains("admin"))
        {
          await userManager.RemoveFromRoleAsync(userToUpgrade, "admin");
        }
        else
        {
          await userManager.AddToRoleAsync(userToUpgrade, "admin");
        }

        await _context.SaveChangesAsync();
        return userToUpgrade.EmailConfirmed;
      }
    }
  }
}