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

    [HttpPost("adminUpgrading")]
    public async Task<IActionResult> ToggleAdminRole([FromBody] UpgradeToAdmin.Command command)
    {
      return Ok(await mediator.Send(command));
    }

    [HttpPost("isAdmin")]
    public async Task<IActionResult> isAdmin([FromBody] IsUserAdmin.Query query)
    {
      return Ok(await mediator.Send(query));
    }
  }
}