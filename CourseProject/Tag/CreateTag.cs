using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Rating;
using MediatR;

namespace CourseProject.Web.Api.Tag
{
    public class CreateTag
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Tag Tag { get; set; }
        }

        public class Handler : AsyncRequestHandler<CreateTag.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(CreateTag.Command command)
            {
                command.Tag.Active = true;
                context.Tags.Add(command.Tag);
                context.SaveChanges();

                return Task.FromResult(command.Tag.Id);
            }
        }
    }
}
