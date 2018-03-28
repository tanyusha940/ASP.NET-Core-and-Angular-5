using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
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
            private readonly ApplicationContext _context;
            private readonly IValidator<Data.Model.Conspect> _validator;
            
            public Handler(ApplicationContext context, IValidator<Data.Model.Conspect> commandValidator)
            {
                _context = context;
                _validator = commandValidator;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                _validator.ValidateAndThrow(request.Conspect);
                var response = await next();
                return response;
            }

            public Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                command.Conspect.CreatedDate = DateTime.Now;
                command.Conspect.Active = true;
                _context.Conspects.Add(command.Conspect);
                _context.SaveChanges();
                return Task.FromResult(command.Conspect.Id);
            }
        }
    }
}
