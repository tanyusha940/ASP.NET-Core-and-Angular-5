using CourseProject.Data.Model.Context;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Api.Services.Conspect
{
    public class DeleteConspect
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
                var conspect = _context.Conspects.First(c => c.Id == command.Id);
                conspect.Active = false;
                _context.SaveChanges();
                return Task.FromResult(command.Id);
            }
        }
    }
}
