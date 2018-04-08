using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                var rates = await _context.Ratings
                    .Where(rate => rate.Active)
                    .Where(rate => rate.ConspectId == query.Id).ToListAsync();
                if (rates.Count == 0)
                {
                  return 0;
                }

                return rates.Average(rate => rate.Mark);
            }
        }
    }
}
