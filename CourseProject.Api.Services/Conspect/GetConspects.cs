using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Conspect
{
    public static class GetConspects
    {
        public class Query : IRequest<IQueryable<Data.Model.Conspect>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<Data.Model.Conspect>>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override async Task<IQueryable<Data.Model.Conspect>> HandleCore(Query query)
            {
                return context.Conspects.Where(conspect => conspect.Active);
            }
        }
    }
}
