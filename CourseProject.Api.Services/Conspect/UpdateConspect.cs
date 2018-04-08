using System.Collections.Generic;
using System.Linq;
using CourseProject.Data.Model.Context;
using MediatR;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.Conspect.Services;
using CourseProject.Data.Model;
using CourseProject.Infrastructure.Authentication;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.Conspect
{
  public class UpdateConspect
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

      public Handler(ApplicationContext context, IValidator<ConspectDto> validator, IUserService userService,
        IConspectService conspectService)
      {
        _context = context;
        _validator = validator;
        this.userService = userService;
        this.conspectService = conspectService;
      }

      protected override async Task<int> HandleCore(Command command)
      {
        var user = await userService.GetUserIdentity(command.UserClaims);
        var conspect = _context.Conspects
          .Where(c => c.Active)
          .First(c => c.Id == command.Conspect.Id);
        conspectService.MapConspectDtoToConspect(command.Conspect, user, conspect);
        conspect.Id = command.Conspect.Id;

        var existingConspectTags = await conspectService.GetExistingConspectTags(command.Conspect.Tags, conspect);
        var newConspectTags = await conspectService.GetNewConspectTag(conspect, command.Conspect.Tags);
        var tagsToDelete = await conspectService.GetConspectTagsToDelete(conspect, command.Conspect.Tags);

        _context.ConspectTags.AddRange(existingConspectTags);
        _context.ConspectTags.AddRange(newConspectTags);
        _context.ConspectTags.RemoveRange(tagsToDelete);

        await _context.SaveChangesAsync();

        return conspect.Id;
      }

      public async Task<int> Handle(Command request, CancellationToken cancellationToken,
        RequestHandlerDelegate<int> next)
      {
        _validator.ValidateAndThrow(request.Conspect);
        var response = await next();
        return response;
      }
    }
  }
}
