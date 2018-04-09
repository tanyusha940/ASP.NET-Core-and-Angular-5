using System.Threading.Tasks;
using CourseProject.Api.Services.AdminPanel;
using CourseProject.Api.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Web.Api.Controllers
{
  [Authorize]
  [Route("api/adminPanel")]
  public class AdminPanelController : Controller
  {
    private readonly IMediator mediator;

    public AdminPanelController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost("block")]
    public async Task<IActionResult> Login([FromBody] BlockUser.Command command)
    {
      return Ok(await mediator.Send(command));
    }
  }
}