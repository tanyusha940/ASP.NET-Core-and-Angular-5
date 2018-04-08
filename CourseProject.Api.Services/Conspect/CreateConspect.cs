using CourseProject.Data.Model.Context;
using MediatR;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.Conspect.Services;
using CourseProject.Infrastructure.Authentication;
using FluentValidation;

namespace CourseProject.Api.Services.Conspect
{
    public class CreateConspect
    {
        public class Command : IRequest<int>
        {
            public ConspectDto Conspect { get; set; }

            public ClaimsPrincipal UserClaims { get; set; }
        }

        public class Handler : AsyncRequestHandler<Command, int>, IPipelineBehavior<Command, int>
        {
          private readonly ApplicationContext _context;
          private readonly IValidator<ConspectDto> _validator;
          private readonly IUserService userService;
          private readonly IConspectService conspectService;

          public Handler(ApplicationContext context, IValidator<ConspectDto> commandValidator,
            IUserService userService, IConspectService conspectService)
          {
            _context = context;
            _validator = commandValidator;
            this.userService = userService;
            this.conspectService = conspectService;
          }

          public async Task<int> Handle(Command request, CancellationToken cancellationToken,
            RequestHandlerDelegate<int> next)
          {
            _validator.ValidateAndThrow(request.Conspect);
            var response = await next();
            return response;
          }

          protected override async Task<int> HandleCore(Command command)
          {
            var user = await userService.GetUserIdentity(command.UserClaims);
            var conspect = conspectService.MapConspectDtoToConspect(command.Conspect, user);
            var existingConspectTags = await conspectService.GetExistingConspectTags(command.Conspect.Tags, conspect);
            var newConspectTags = await conspectService.GetNewConspectTag(conspect, command.Conspect.Tags);

            _context.Conspects.Add(conspect);
            _context.ConspectTags.AddRange(existingConspectTags);
            _context.ConspectTags.AddRange(newConspectTags);

            await _context.SaveChangesAsync();

            return conspect.Id;
          }
        }
    }
}
