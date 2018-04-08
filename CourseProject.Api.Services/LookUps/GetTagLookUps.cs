using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Api.Services.Tag.Models;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.LookUps
{
  public class GetTagLookUps
  {
    public class Query : IRequest<IQueryable<LookUp>>
    {

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
        return _context.Tags.Where(tag => tag.Active)
          .Select(tag => new LookUp
          {
            Id = tag.Id,
            Text = tag.Text
          });
      }
    }
  }
}