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

        public class Handler : AsyncRequestHandler<DeleteTag.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(DeleteTag.Command command)
            {
                var tag = context.Tags.First(t => t.Id == command.Id);
                context.Remove(tag);
                context.SaveChanges();
                return Task.FromResult(command.Id);
            }
        }
    }
}
