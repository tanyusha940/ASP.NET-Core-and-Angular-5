using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Comment
{
    public class GetComment
    {
        public class Query : IRequest<Data.Model.Comment>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, Data.Model.Comment>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override Task<Data.Model.Comment> HandleCore(Query query)
            {
                return Task.FromResult(_context.Comments
                    .Where(comment => comment.Active)
                    .First(comment => comment.Id == query.Id));
            }
        }
    }
}
