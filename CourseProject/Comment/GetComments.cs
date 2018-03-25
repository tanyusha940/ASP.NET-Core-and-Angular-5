using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Web.Api.Comment
{
    public class GetComments
    {
        public class Query : IRequest<IQueryable<Data.Model.Comment>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Comment>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override async Task<IQueryable<Data.Model.Comment>> HandleCore(Query query)
            {
                return context.Comments.Where(comment => comment.Active);
            }
        }
    }
}
