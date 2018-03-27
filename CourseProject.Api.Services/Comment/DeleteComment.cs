using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Comment
{
    public class DeleteComment
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
                var comments = _context.Comments.First(c => c.Conspect.Id == command.ConspectId);
                comments.Active = false;
                _context.SaveChanges();
                return Task.FromResult(command.ConspectId);
            }
        }
    }
}
