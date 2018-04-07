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
            
            public Handler(ApplicationContext context, IValidator<ConspectDto> commandValidator, UserManager<UserIdentity> userManager)
            {
                _context = context;
                _validator = commandValidator;
              this.userManager = userManager;
            }

            public async Task<int> Handle(Command request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
            {
                _validator.ValidateAndThrow(request.Conspect);
                var response = await next();
                return response;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var user = await userManager.GetUserAsync(command.UserClaims);
                var conspect = MapConspect(command.Conspect);
                var tags = command.Tags;
                var conspectTags = tags.Select(tag => new ConspectTag
                    {
                        Conspect = conspect,
                        Tag = new Data.Model.Tag
                        {
                          Text = tag.Text,
                          Active = true
                        }
                    })
                    .ToList();

                conspect.CreatedDate = DateTime.Now;
                conspect.Active = true;
                conspect.User = user;
                conspect.ConspectTags = conspectTags;
                _context.Conspects.Add(conspect);
                _context.ConspectTags.AddRange(conspectTags);
                _context.SaveChanges();
                return conspect.Id;
            }


          private Data.Model.Conspect MapConspect(ConspectDto conspectDto)
          {
            return new Data.Model.Conspect
            {
              Name = conspectDto.Name,
              Content = conspectDto.Content,
              SpecialityNumberId = conspectDto.SpecialityNumberId
            };
          }
        }
    }
}
