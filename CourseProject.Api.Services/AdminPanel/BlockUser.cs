using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.AdminPanel
{
  public class BlockUser
  {
    public class Command : IRequest<bool>
    {
      public string UserId { get; set; }
    }

    public class Handler : AsyncRequestHandler<Command, bool>
    {
      private readonly ApplicationContext _context;

      public Handler(ApplicationContext context)
      {
        _context = context;
      }

      protected override async Task<bool> HandleCore(Command command)
      {
        var userToBlock = _context.Users
          .First(user => user.Id == command.UserId);
        userToBlock.Active = !userToBlock.Active;

        await _context.SaveChangesAsync();
        return userToBlock.Active;
      }
    }
  }
}