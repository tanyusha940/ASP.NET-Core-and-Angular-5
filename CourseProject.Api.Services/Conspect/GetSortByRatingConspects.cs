using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Conspect
{
    public class GetSortByRatingConspects
    {
        public class Query : IRequest<IQueryable<Data.Model.Conspect>>
        {

        }

        public class Handler : AsyncRequestHandler<GetSortByRatingConspects.Query, IQueryable<Data.Model.Conspect>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<IQueryable<Data.Model.Conspect>> HandleCore(GetSortByRatingConspects.Query query)
            {
                return _context.Conspects
                    .Where(conspect => conspect.Active)
                    .OrderByDescending(c => c.Ratings.Average(rating => rating.Mark));
            }
        }
    }
}
