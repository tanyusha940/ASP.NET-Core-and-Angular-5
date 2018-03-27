using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
    public class CalculateConspectRating
    {
        public class Query : IRequest<double>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, double>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<double> HandleCore(Query query)
            {
                return _context.Ratings
                    .Where(rating => rating.Active)
                    .Where(rating => rating.ConspectId == query.Id)
                    .Average(rating => rating.Mark);
            }
        }
    }
}
