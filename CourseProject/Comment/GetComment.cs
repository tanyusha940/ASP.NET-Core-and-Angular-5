using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Conspect;
using MediatR;

namespace CourseProject.Web.Api.Comment
{
    public class GetComment
    {
        public class Query : IRequest<Data.Model.Comment>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<GetComment.Query, Data.Model.Comment>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<Data.Model.Comment> HandleCore(GetComment.Query query)
            {
                return Task.FromResult(context.Comments
                    .Where(comment => comment.Active)
                    .First(comment => comment.Id == query.Id));
            }
        }
    }
}
