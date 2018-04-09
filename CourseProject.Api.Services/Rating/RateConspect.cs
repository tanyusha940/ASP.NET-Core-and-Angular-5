using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.Rating
{
    public class RateConspect
    {
        public class Command : IRequest<int>
        {
            public ClaimsPrincipal ClaimsPrincipal { get; set; }
            public int ConspectId { get; set; }
            public int Mark { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>
        {
            private readonly ApplicationContext _context;
            private readonly IUserService userService;

            public Handler(ApplicationContext context, IUserService userService)
            {
              _context = context;
              this.userService = userService;
            }

            protected override async Task<int> HandleCore(Command command)
            {
                var user = await userService.GetUserIdentity(command.ClaimsPrincipal);
                var isUserMarkConspect = await _context.Ratings
                    .Where(rating => rating.Active)
                    .Where(rating => rating.IdentityId == user.Id)
                    .AnyAsync(rating => rating.ConspectId == command.ConspectId);

              var conspect = _context.Conspects.First(c => c.Id == command.ConspectId);

              if (!isUserMarkConspect)
              {
                _context.Ratings.Add(new Data.Model.Rating
                {
                  Identity = user,
                  Conspect = conspect,
                  Mark = command.Mark,
                  Active = true
                });
                await _context.SaveChangesAsync();
              }

              return conspect.Id;
            }
        }
    }
}
