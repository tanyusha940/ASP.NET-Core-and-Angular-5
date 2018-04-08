using System;
using System.Threading.Tasks;
using CourseProject.Api.Services.User.Services;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CourseProject.Api.Services.User
{
  public static class CreateUser
  {
    public class Command : IRequest<string>
    {
      public string Username { get; set; }

      public string Email { get; set; }

      public string Password { get; set; }

      public IUrlHelper UrlHelper { get; set; }
    }

    public class Handler : AsyncRequestHandler<Command, string>
    {
      private readonly ApplicationContext partyPlannerContext;
      private readonly UserManager<UserIdentity> userManager;
      private readonly IEmailService emailService;

      public Handler(ApplicationContext partyPlannerContext, UserManager<UserIdentity> userManager, IEmailService emailService)
      {
        this.partyPlannerContext = partyPlannerContext;
        this.userManager = userManager;
        this.emailService = emailService;
      }

      protected override async Task<string> HandleCore(Command request)
      {
        var identity = await CreateUserIdentity(request);
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

      private async Task<UserIdentity> CreateUserIdentity(Command request)
      {
        var identity = new UserIdentity
        {
          UserName = request.Username,
          Email = request.Email
        };
        var result = await userManager.CreateAsync(identity, request.Password);
        if (result.Succeeded)
        {
          await userManager.AddToRoleAsync(identity, "user");
          await SendConfirmationMail(identity, request.UrlHelper);
        }

        return identity;
      }

      private async Task SendConfirmationMail(UserIdentity userIdentity, IUrlHelper urlHelper)
      {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
        var callbackUrl = urlHelper.Action("ConfirmEmail", "User", new
        {
          userId = userIdentity.Id,
          code = code
        });
        await emailService.SendEmailAsync(userIdentity.Email, "Confirm your account",
          $"Подтвердите регистрацию, перейдя по ссылке: <a href='http://localhost:24606{callbackUrl}'>link</a>");
      }
    }
  }
}