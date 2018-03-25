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

        public class Handler : AsyncRequestHandler<DeleteComment.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(DeleteComment.Command command)
            {
                var comments = context.Comments.First(c => c.Conspect.Id == command.ConspectId);
                comments.Active = false;
                context.SaveChanges();
                return Task.FromResult(command.ConspectId);
            }
        }
    }
}
