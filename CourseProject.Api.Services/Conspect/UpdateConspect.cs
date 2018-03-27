using CourseProject.Data.Model.Context;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Api.Services.Conspect
{
    public class UpdateConspect
    {
        public class Command : IRequest<int>
        {
            public Data.Model.Conspect Conspect { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
                _context = context;
            }

            protected override Task<int> HandleCore(Command command)
            {
                var conspectDto = command.Conspect;
                var conspect = _context.Conspects.First(c => c.Id == command.Conspect.Id);
                conspect.Name = conspectDto.Name;
                conspect.Content = conspectDto.Content;
                conspect.UpdatedDate = conspect.UpdatedDate;
                return Task.FromResult(conspect.Id);
            }
        }
    }
}
