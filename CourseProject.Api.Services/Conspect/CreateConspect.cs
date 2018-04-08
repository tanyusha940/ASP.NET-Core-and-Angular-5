using CourseProject.Data.Model.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect.Models;
using CourseProject.Api.Services.LookUps.Models;
using CourseProject.Data.Model;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.Conspect
{
    public class CreateConspect
    {
        public class Command : IRequest<int>
        {
            public ConspectDto Conspect { get; set; }

            public ICollection<LookUp> Tags { get; set; }

            public ClaimsPrincipal UserClaims { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>, IPipelineBehavior<Command, int>
        {
          private readonly ApplicationContext _context;
          private readonly IValidator<ConspectDto> _validator;
          private readonly UserManager<UserIdentity> userManager;

          public Handler(ApplicationContext context, IValidator<ConspectDto> commandValidator,
            UserManager<UserIdentity> userManager)
          {
            _context = context;
            _validator = commandValidator;
            this.userManager = userManager;
          }

          public async Task<int> Handle(Command request, CancellationToken cancellationToken,
            RequestHandlerDelegate<int> next)
          {
            _validator.ValidateAndThrow(request.Conspect);
            var response = await next();
            return response;
          }

          public async Task<int> Handle(Command command, CancellationToken cancellationToken)
          {
            var user = await GetUserIdentity(command.UserClaims);
            var conspect = MapConspect(command.Conspect, user);
            var existingConspectTags = await GetExistingConspectTags(command.Tags, conspect);
            var newConspectTags = await GetNewConspectTag(conspect, command.Tags);

            _context.Conspects.Add(conspect);
            _context.ConspectTags.AddRange(existingConspectTags);
            _context.ConspectTags.AddRange(newConspectTags);

            await _context.SaveChangesAsync(cancellationToken);

            return conspect.Id;
          }


          private Data.Model.Conspect MapConspect(ConspectDto conspectDto, UserIdentity user)
          {
            return new Data.Model.Conspect
            {
              Name = conspectDto.Name,
              Content = conspectDto.Content,
              SpecialityNumberId = conspectDto.SpecialityNumberId,
              CreatedDate = DateTime.Now,
              Active = true,
              User = user
            };
          }

          private async Task<IList<ConspectTag>> GetExistingConspectTags(ICollection<LookUp> TagLookUps,
            Data.Model.Conspect conspect)
          {
            var tagNames = TagLookUps.Select(tag => tag.Text.ToLower());
            var existingTags = _context.Tags.Where(tag => tagNames.Contains(tag.Text.ToLower()));
            var conspectTags = await existingTags.Select(tag => new ConspectTag
              {
                TagId = tag.Id,
                Conspect = conspect
              })
              .ToListAsync();

            return conspectTags;
          }

          private async Task<IList<ConspectTag>> GetNewConspectTag(Data.Model.Conspect conspect, ICollection<LookUp> TagLookUps)
          {
            var tagNames = TagLookUps.Select(tag => tag.Text.ToLower());
            var existingTags = await _context.Tags.Where(tag => tagNames.Contains(tag.Text.ToLower())).ToListAsync();
            var newTags = tagNames.Where(name => !existingTags.Select(tag => tag.Text).Contains(name)).ToList();
            var newConspectTags = newTags.Select(tag => new ConspectTag
            {
              Conspect = conspect,
              Tag = new Data.Model.Tag
              {
                Text = tag,
                Active = true
              }
            })
              .ToList();

            return newConspectTags;
          }

          private async Task<UserIdentity> GetUserIdentity(ClaimsPrincipal userClaims)
          {
            var userName = userClaims.Identities
              .First()
              .Claims.First().Value;
            var userIdentity = await userManager.FindByNameAsync(userName);

            return userIdentity;
          }
        }
    }
}
