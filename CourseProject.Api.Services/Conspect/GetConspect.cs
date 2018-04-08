using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.Conspect
{
    public class GetConspect
    {
        public class Query : IRequest<ConspectDto>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, ConspectDto>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected async override Task<ConspectDto> HandleCore(Query query)
            {
                var tags = await _context.ConspectTags
                    .Include(conspectTag => conspectTag.Tag)
                    .Where(conspectTag => conspectTag.ConspectId == query.Id)
                    .Select(conspectTag => new LookUp
                    {
                        Id = conspectTag.TagId,
                        Text = conspectTag.Tag.Text
                    })
                    .ToListAsync();

                var result = _context.Conspects
                    .Where(conspect => conspect.Active)
                    .Select(conspect => new ConspectDto
                    {
                        Id = conspect.Id,
                        Name = conspect.Name,
                        SpecialityNumberId = conspect.SpecialityNumberId,
                        Content = conspect.Content,
                        Tags = tags
                    })
                    .First(conspect => conspect.Id == query.Id);
                return result;
            }
        }
    }
}
