using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Comment
{
    public class GetComments
    {
        public class Query : IRequest<IQueryable<Data.Model.Comment>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Comment>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<IQueryable<Data.Model.Comment>> HandleCore(Query query)
            {
                return _context.Comments.Where(comment => comment.Active);
            }
        }
    }
}
