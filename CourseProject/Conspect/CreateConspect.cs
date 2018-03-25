using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Web.Api.Conspect
{
    public class CreateConspect
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
                command.Conspect.CreatedDate = DateTime.Now;
                command.Conspect.Active = true;
                context.Conspects.Add(command.Conspect);
                context.SaveChanges();
                return Task.FromResult(command.Conspect.Id);
            }
        }
    }
}
