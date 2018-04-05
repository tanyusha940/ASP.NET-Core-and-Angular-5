using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.Tag.Models;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Tag
{
    public class GetTags
    {
        public class Query : IRequest<IQueryable<TagDto>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<TagDto>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<IQueryable<TagDto>> HandleCore(Query query)
            {
                return _context.Tags.Where(tag => tag.Active)
                    .Select(tag => new TagDto
                    {
                        Id = tag.Id,
                        Value = tag.Text
                    });
            }
        }
    }
}
