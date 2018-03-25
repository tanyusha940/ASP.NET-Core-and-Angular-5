using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Web.Api.Conspect
{
    public class DeleteConspect
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
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
                var conspect = context.Conspects.First(c => c.Id == command.Id);
                conspect.Active = false;
                context.SaveChanges();
                return Task.FromResult(command.Id);
            }
        }
    }
}
