using System.Linq;
using System.Threading.Tasks;
using CourseProject.Api.Services.User.Models;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Api.Services.User
{
    public class GetUsers
    {
        public class Query : IRequest<IQueryable<UserDto>>
        {

        }

        public class Handler : AsyncRequestHandler<Query, IQueryable<UserDto>>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context)
            {
              _context = context;
            }

            protected override async Task<IQueryable<UserDto>> HandleCore(Query query)
            {
                return _context.Users
                  .Select(user => new UserDto
                {
                  Id = user.IdentityId,
                  Active = user.Active,
                  Email = user.Identity.Email,
                  Name = user.Identity.UserName
                });
            }
        }
    }
}
