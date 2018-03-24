using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Web.Api.Conspect
{
    public static class GetConspetcs
    {
        public class Query : IRequest<IQueryable<Data.Model.Conspect>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Conspect>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override async Task<IQueryable<Data.Model.Conspect>> HandleCore(Query request)
            {
                return context.Conspects;
            }
        }
    }
}
