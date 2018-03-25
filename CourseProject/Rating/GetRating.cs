using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Conspect;
using MediatR;

namespace CourseProject.Web.Api.Rating
{
    public class GetRating
    {
        public class Query : IRequest<IQueryable<Data.Model.Rating>>
        {
            public string UserId { get; set; }
            public int ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<GetRating.Query, IQueryable<Data.Model.Rating>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<IQueryable<Data.Model.Rating>> HandleCore(GetRating.Query query)
            {
                return Task.FromResult(context.Ratings
                    .Where(rating => rating.Active)
                    .Where(id => id.UserId == query.UserId && id.ConspectId == query.ConspectId));
            }
        }
    }
}
