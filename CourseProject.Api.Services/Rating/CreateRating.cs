using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.Data.Model.Context;
using MediatR;

namespace CourseProject.Api.Services.Rating
{
    public class CreateRating
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Rating Rating { get; set; }

            public int ConspectId { get; set; }
        }

        public class Handler : AsyncRequestHandler<CreateRating.Command, int>
        {
            private readonly ApplicationContext context;

            public Handler(ApplicationContext context)
            {
                this.context = context;
            }

            protected override Task<int> HandleCore(CreateRating.Command command)
            {
                command.Rating.ConspectId = command.ConspectId;
                command.Rating.Active = true;
                context.Ratings.Add(command.Rating);
                context.SaveChanges();

                return Task.FromResult(command.Rating.Id);
            }
        }
    }
}
