using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Tag
{
    public class GetConpectTags
    {
        public class Query : IRequest<IQueryable<Data.Model.Tag>>
        {
            public int ConspectId { get; set; }

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Tag>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<IQueryable<Data.Model.Tag>> HandleCore(Query query)
            {
                return Task.FromResult(context.ConspectTags
                    .Where(conspectTag => conspectTag.ConspectId == query.ConspectId)
                    .Select(conspectTag => conspectTag.Tag));
            }
        }
    }
}
