using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/LookUp")]
    public class LookUpController : Controller
    {
      private readonly IMediator _mediator;

      public LookUpController(IMediator mediator)
      {
        _mediator = mediator;
      }

      [HttpGet("tags")]
      public async Task<IActionResult> Get()
      {
        return Ok(await _mediator.Send(new GetTagLookUps.Query()));
      }
  }
}