using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model.Context;
using CourseProject.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.LookUps
{
  public class GetUserConspectLookUps
  {
    public class Query : IRequest<List<ConspectLookUp>>
    {
        public ClaimsPrincipal UserClaims { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, List<ConspectLookUp>>
    {
      private readonly ApplicationContext _context;
      private readonly IUserService userService;

      public Handler(ApplicationContext context, IUserService userService)
      {
        _context = context;
        this.userService = userService;
      }

      protected override async Task<List<ConspectLookUp>> HandleCore(Query query)
      {
        var user = await userService.GetUserIdentity(query.UserClaims);
        return await _context.Conspects
          .Where(conspect => conspect.Active)
          .Where(conspect => conspect.User.Id == user.Id)
          .Select(conspect => new ConspectLookUp
          {
            Id = conspect.Id,
            Text = conspect.Name,
            SpecialityNumberId = conspect.SpecialityNumberId,
            CreatedDate = conspect.CreatedDate,
            UserName = conspect.User.UserName
          }).ToListAsync();
      }
    }
  }
}