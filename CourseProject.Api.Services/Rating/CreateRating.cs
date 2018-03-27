using System.Threading;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using FluentValidation;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
    public class CreateRating
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Rating Rating { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>, IPipelineBehavior<Command, int>
        {
            private readonly ApplicationContext _context;
            private readonly IValidator<Data.Model.Rating> _validator;

            public Handler(ApplicationContext context, IValidator<Data.Model.Rating> validator)
            {
                _context = context;
                _validator = validator;
            }

            protected override Task<int> HandleCore(Command command)
            {
                command.Rating.Active = true;
                _context.Ratings.Add(command.Rating);
                _context.SaveChanges();

                return Task.FromResult(command.Rating.Id);
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                _validator.ValidateAndThrow(request.Rating);

                var response = await next();

                return response;
            }
        }
    }
}
