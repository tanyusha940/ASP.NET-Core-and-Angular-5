using System;
using System.Collections.Generic;
using System.Linq;
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

        public class Handler : AsyncRequestHandler<CreateRating.Command, int>, IPipelineBehavior<CreateRating.Command, int>
        {
            private readonly ApplicationContext context;
            private readonly IValidator<Data.Model.Rating> validator;

            public Handler(ApplicationContext context, IValidator<Data.Model.Rating> validator)
            {
                this.context = context;
                this.validator = validator;
            }

            protected override Task<int> HandleCore(CreateRating.Command command)
            {
                command.Rating.Active = true;
                context.Ratings.Add(command.Rating);
                context.SaveChanges();

                return Task.FromResult(command.Rating.Id);
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                var result = validator.Validate(request.Rating);

                var response = await next();

                return response;
            }
        }
    }
}
