using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Comment;
using MediatR;

namespace CourseProject.Web.Api.Rating
{
    public class DeleteRating
    {
        public class Command : IRequest<int>
        {
            public int ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<DeleteRating.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(DeleteRating.Command command)
            {
                var rating = context.Ratings.First(r => r.ConspectId == command.ConspectId);
                rating.Active = false;
                context.SaveChanges();
                return Task.FromResult(command.ConspectId);
            }
        }
    }
}
