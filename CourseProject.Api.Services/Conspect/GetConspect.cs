using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Conspect
{
    public class GetConspect
    {
        public class Query : IRequest<Data.Model.Conspect>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, Data.Model.Conspect>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<Data.Model.Conspect> HandleCore(Query query)
            {
                return Task.FromResult(context.Conspects
                    .Where(conspect => conspect.Active)
                    .First(conspect => conspect.Id == query.Id)
                );
            }
        }
    }
}
