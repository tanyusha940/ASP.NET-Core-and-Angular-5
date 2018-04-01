using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Data.Model;
using FluentValidation;

namespace CourseProject.Api.Services.Conspect
{
    public class CreateConspect
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Conspect Conspect { get; set; }

            public IEnumerable<Data.Model.Tag> Tags { get; set; }
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
                var conspect = command.Conspect;
                var tags = command.Tags;
                var conspectTags = tags.Select(tag => new ConspectTag
                    {
                        Conspect = conspect,
                        Tag = tag
                    })
                    .ToList();

                conspect.CreatedDate = DateTime.Now;
                conspect.Active = true;
                conspect.ConspectTags = conspectTags;
                _context.Conspects.Add(conspect);
                _context.ConspectTags.AddRange(conspectTags);
                _context.SaveChanges();
                return Task.FromResult(conspect.Id);
            }
        }
    }
}
