using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.LookUps
{
    public class GetSortByDateConspects
    {
        public class Query : IRequest<List<ConspectLookUp>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, List<ConspectLookUp>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override async Task<List<ConspectLookUp>> HandleCore(Query query)
            {
                return await _context.Conspects
                    .Where(conspect => conspect.Active)
                    .OrderByDescending(c=>c.CreatedDate)
                    .Select(conspect => new ConspectLookUp
                  {
                    Id = conspect.Id,
                    Text = conspect.Name,
                    SpecialityNumberId = conspect.SpecialityNumberId,
                    CreatedDate = conspect.CreatedDate
                 }).ToListAsync();
            }
        }
    }
}
