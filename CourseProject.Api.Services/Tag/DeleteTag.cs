using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Tag
{
    public class DeleteTag
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
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
                var tag = _context.Tags.First(t => t.Id == command.Id);
                _context.Remove(tag);
                _context.SaveChanges();
                return Task.FromResult(command.Id);
            }
        }
    }
}
