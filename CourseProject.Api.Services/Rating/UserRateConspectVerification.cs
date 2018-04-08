using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Infrastructure.Authentication;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
  public class UserRateConspectVerification
  {
    public class Query : IRequest<bool>
    {
      public int ConspectId { get; set; }

      public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, bool>
    {
      private readonly ApplicationContext _context;
      private readonly IUserService userService;

      public Handler(ApplicationContext context, IUserService userService)
      {
        _context = context;
        this.userService = userService;
      }

      protected override async Task<bool> HandleCore(Query query)
      {
        var user = await userService.GetUserIdentity(query.ClaimsPrincipal);

        return _context.Ratings
          .Where(rating => rating.IdentityId == user.Id)
          .All(rating => rating.ConspectId != query.ConspectId);
      }
    }
  }
}