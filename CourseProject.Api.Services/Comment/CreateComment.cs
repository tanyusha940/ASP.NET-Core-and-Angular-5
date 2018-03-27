using System;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using FluentValidation;
using MediatR;

namespace CourseProject.Api.Services.Comment
{
    public class CreateComment
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Comment Comment { get; set; }

            public int  ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>, IPipelineBehavior<Command, int>
        {
            private readonly ApplicationContext _context;
            private readonly IValidator<Data.Model.Comment> _validator; 

            public Handler(ApplicationContext context, IValidator<Data.Model.Comment> validator)
            {
                _context = context;
                _validator = validator;
            }

            protected override Task<int> HandleCore(Command command)
            {
                command.Comment.CreatedDate = DateTime.Now;
                command.Comment.Active = true;
                command.Comment.ConspectId = command.ConspectId;
                _context.Comments.Add(command.Comment);
                _context.SaveChanges();
                return Task.FromResult(command.Comment.Id);
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                _validator.Validate(request.Comment);

                var response = await next();

                return response;
            }
        }
    }
}
