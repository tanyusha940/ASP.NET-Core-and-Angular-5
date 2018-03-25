using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Tag
{
    public class GetTags
    {
        public class Query : IRequest<IQueryable<Data.Model.Tag>>
        {

        }

        public class Handler : AsyncRequestHandler<GetTags.Query, IQueryable<Data.Model.Tag>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override async Task<IQueryable<Data.Model.Tag>> HandleCore(GetTags.Query query)
            {
                return context.Tags.Where(tag => tag.Active);
            }
        }
    }
}
