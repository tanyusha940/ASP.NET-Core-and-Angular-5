using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.LookUps
{
  public class GetConspectTagsLookUps
  {
    public class Query : IRequest<IQueryable<LookUp>>
    {
      public int Id { get; set; }
    }

    public class Handler : AsyncRequestHandler<Query, IQueryable<LookUp>>
    {
      private readonly ApplicationContext _context;

      public Handler(ApplicationContext context)
      {
        _context = context;
      }

      protected override async Task<IQueryable<LookUp>> HandleCore(Query query)
      {
        return _context.ConspectTags
          .Include(conspectTag => conspectTag.Tag)
          .Where(conspectTag => conspectTag.ConspectId == query.Id)
          .Select(conspectTag => new LookUp
          {
            Id = conspectTag.TagId,
            Text = conspectTag.Tag.Text
          });
      }
    }
  }
}