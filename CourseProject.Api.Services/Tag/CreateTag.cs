using System.Threading;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using FluentValidation;
using MediatR;

namespace CourseProject.Api.Services.Tag
{
    public class CreateTag
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Tag Tag { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>,IPipelineBehavior<Command, int>
        {
            private readonly ApplicationContext _context;
            private readonly IValidator<Data.Model.Tag> _validator;

            public Handler(ApplicationContext context, IValidator<Data.Model.Tag> validator)
            {
                _context = context;
                _validator = validator;
            }

            protected override Task<int> HandleCore(Command command)
            {
                command.Tag.Active = true;
                _context.Tags.Add(command.Tag);
                _context.SaveChanges();

                return Task.FromResult(command.Tag.Id);
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                _validator.Validate(request.Tag);

                var response = await next();

                return response;
            }
        }
    }
}
