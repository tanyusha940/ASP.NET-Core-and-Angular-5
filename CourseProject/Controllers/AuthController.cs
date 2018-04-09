using System.Threading.Tasks;
using CourseProject.Api.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Web.Api.Controllers
{
  [Produces("application/json")]
  [Route("api/login")]
  [IgnoreAntiforgeryToken]
  public class AuthController : Controller
  {
    private readonly IMediator mediator;

    public AuthController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Login.Query query)
    {
      return Ok(await mediator.Send(query));
    }
  }
}