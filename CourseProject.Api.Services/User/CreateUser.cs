using System;
using System.Threading.Tasks;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseProject.Api.Services.User
{
  public static class CreateUser
  {
    public class Command : IRequest<string>
    {
      public string Username { get; set; }

      public string Password { get; set; }
    }

    public class Handler : AsyncRequestHandler<Command, string>
    {
      private readonly ApplicationContext partyPlannerContext;
      private readonly UserManager<UserIdentity> userManager;

      public Handler(ApplicationContext partyPlannerContext, UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager)
      {
        this.partyPlannerContext = partyPlannerContext;
        this.userManager = userManager;
      }

      protected override async Task<string> HandleCore(Command request)
      {
        var identity = new UserIdentity
        {
          UserName = request.Username
        };
        var result = await userManager.CreateAsync(identity, request.Password);
        if (result.Succeeded)
        {
          await userManager.AddToRoleAsync(identity, "user");
        }

        var user = new Data.Model.User
        {
          Id = Guid.NewGuid().ToString(),
          Identity = identity,
          Active = true
        };

        partyPlannerContext.Users.Add(user);

        await partyPlannerContext.SaveChangesAsync();

        return user.Id;
      }
    }
  }
}