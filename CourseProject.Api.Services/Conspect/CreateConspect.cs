using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using FluentValidation;

namespace CourseProject.Api.Services.Conspect
{
    public class CreateConspect
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Conspect Conspect { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>, IPipelineBehavior<Command, int>
        {
            private readonly IValidator<Data.Model.Conspect> validator;
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context, IValidator<Data.Model.Conspect> commandValidator)
            {
                this.context = context;
                this.validator = commandValidator;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                validator.ValidateAndThrow(request.Conspect);

                var response = await next();

                return response;
            }

            public Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                command.Conspect.CreatedDate = DateTime.Now;
                command.Conspect.Active = true;
                context.Conspects.Add(command.Conspect);
                context.SaveChanges();
                return Task.FromResult(command.Conspect.Id);
            }
        }
    }
}
