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

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Tag>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<IQueryable<Data.Model.Tag>> HandleCore(Query query)
            {
                return _context.Tags.Where(tag => tag.Active);
            }
        }
    }
}
