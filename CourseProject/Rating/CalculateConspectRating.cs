using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Web.Api.Rating
{
    public class CalculateConspectRating
    {
        public class Query : IRequest<double>
        {
            public int Id { get; set; }
        }

        public class Handler : AsyncRequestHandler<Query, double>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override async Task<double> HandleCore(Query query)
            {
                return context.Ratings
                    .Where(rating => rating.Active)
                    .Where(rating => rating.ConspectId == query.Id)
                    .Average(rating => rating.Mark);
            }
        }
    }
}
