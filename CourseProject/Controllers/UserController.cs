using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CourseProject.Api.Services.Auth;
using CourseProject.Api.Services.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CourseProject.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [IgnoreAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(IMediator mediator, RoleManager<IdentityRole> roleManager)
        {
          _mediator = mediator;
          _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser.Command command)
        {
          command.UrlHelper = new UrlHelper(Url.ActionContext);
          return Ok(await _mediator.Send(command));
        }

        [HttpPost("role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateUser.Command command)
        {
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole("user"));

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetUsers.Query()));
        }


        [HttpGet("confirm")]
        public async Task ConfirmEmail(ConfirmEmail.Query query)
        {
          var result = await _mediator.Send(query);
          string url = $"http://localhost:4200/home?confirmSuccess={result}";
          Response.Redirect(url);
        }
  }
}