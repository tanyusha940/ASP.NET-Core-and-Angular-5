using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
    public class GetRating
    {
        public class Query : IRequest<IQueryable<Data.Model.Rating>>
        {
            public string UserId { get; set; }
            public int ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Rating>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override Task<IQueryable<Data.Model.Rating>> HandleCore(Query query)
            {
                return Task.FromResult(_context.Ratings
                    .Where(rating => rating.Active)
                    .Where(id => id.UserId == query.UserId && id.ConspectId == query.ConspectId));
            }
        }
    }
}
