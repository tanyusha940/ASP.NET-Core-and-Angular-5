using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
    public class DeleteRating
    {
        public class Command : IRequest<int>
        {
            public int ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override Task<int> HandleCore(Command command)
            {
                var rating = _context.Ratings.First(r => r.ConspectId == command.ConspectId);
                rating.Active = false;
                _context.SaveChanges();
                return Task.FromResult(command.ConspectId);
            }
        }
    }
}
