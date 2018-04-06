﻿using System.Threading.Tasks;
using CourseProject.Api.Services.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Web.Api.Controllers
{
  [Produces("application/json")]
    [Route("api/User")]
    [IgnoreAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        private readonly RoleManager<IdentityRole> roleManager;

    public UserController(IMediator mediator, RoleManager<IdentityRole> roleManager)
    {
      this.mediator = mediator;
      this.roleManager = roleManager;
    }

      [HttpPost]
      public async Task<IActionResult> CreateUser([FromBody] CreateUser.Command command)
      {
          return Ok(await mediator.Send(command));
      }

      [HttpPost("role")]
      public async Task<IActionResult> CreateRole([FromBody] CreateUser.Command command)
      {
        IdentityResult result = await roleManager.CreateAsync(new IdentityRole("user"));

        return Ok();
      }
  }
}