using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Api.Services.Auth.Models;
using CourseProject.Api.Services.Auth.Services;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using CourseProject.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CourseProject.Api.Services.Auth
{
  public static class Login
  {
    public class Query : IRequest<Credentials>
    {
      public string Username { get; set; }

      public string Password { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, Credentials>
    {
      private readonly UserManager<UserIdentity> _userManager;
      private readonly ApplicationContext context;
      private readonly IJwtFactory _jwtFactory;
      private readonly JwtIssuerOptions _jwtOptions;

      public Handler(
                    UserManager<UserIdentity> userManager,
                    IJwtFactory jwtFactory,
                    JwtIssuerOptions jwtOptions, ApplicationContext context)
      {
        _userManager = userManager;
        _jwtFactory = jwtFactory;
        _jwtOptions = jwtOptions;
        this.context = context;
      }

      protected async override Task<Credentials> HandleCore(Query request)
      {
        var claims = await GetClaimsIdentity(request.Username, request.Password);
        var userIdentity = await _userManager.FindByNameAsync(request.Username);
        var user = context.Users.First(u => u.IdentityId == userIdentity.Id);
        if (!user.Active)
        {
          return new Credentials
          {
            Active = false,
          };
        }
        var role = await _userManager.GetRolesAsync(userIdentity);

        if (!await _userManager.IsEmailConfirmedAsync(userIdentity))
        {
          return new Credentials
          {
            IsEmailConfirmed = false,
            Active = user.Active
          };
        }

        return new Credentials
        {
          Id = claims.Claims.Single(c => c.Type == "id").Value,
          Username = request.Username,
          Token = await _jwtFactory.GenerateEncodedToken(request.Username, claims),
          ExpiresIn = (int)_jwtOptions.ValidFor.TotalSeconds,
          Role = role.FirstOrDefault(),
          IsEmailConfirmed = true,
          Active = user.Active
        };
      }

      private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
      {
        if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
        {
          // get the user to verifty
          var userToVerify = await _userManager.FindByNameAsync(userName);

          if (userToVerify != null)
          {
            // check the credentials  
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
              return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }
          }
        }

        // Credentials are invalid, or account doesn't exist
        return await Task.FromResult<ClaimsIdentity>(null);
      }
    }
  }
}