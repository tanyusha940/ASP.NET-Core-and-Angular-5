using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Api.Services.Conspect
{
    public class UpdateConspect
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Conspect Conspect { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(Command command)
            {
                var conspectDto = command.Conspect;
                var conspect = context.Conspects.First(c => c.Id == command.Conspect.Id);
                conspect.Name = conspectDto.Name;
                conspect.Content = conspectDto.Content;
                conspect.UpdatedDate = conspect.UpdatedDate;
                return Task.FromResult(conspect.Id);
            }
        }
    }
}
