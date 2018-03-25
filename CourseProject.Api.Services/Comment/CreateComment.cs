using System;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace  CourseProject.Api.Services.Comment
{
    public class CreateComment
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Comment Comment { get; set; }

            public int  ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<CreateComment.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(CreateComment.Command command)
            {
                command.Comment.CreatedDate = DateTime.Now;
                command.Comment.Active = true;
                command.Comment.ConspectId = command.ConspectId;
                context.Comments.Add(command.Comment);
                context.SaveChanges();
                return Task.FromResult(command.Comment.Id);
            }
        }
    }
}
