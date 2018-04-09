using System.Threading.Tasks;
using CourseProject.Api.Services.LookUps;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

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

      [HttpGet("tags/{id}")]
      public async Task<IActionResult> GetConspectTags([FromRoute] GetConspectTagsLookUps.Query query)
      {
        return Ok(await _mediator.Send(query));
      }

      [Authorize]
      [HttpGet("conspects/user")]
      public async Task<IActionResult> GetUserConspect([FromRoute] GetUserConspectLookUps.Query query)
      {
        query.UserClaims = User;
        return Ok(await _mediator.Send(query));
      }

      [Route("conspects/latest")]
      [HttpGet]
      public async Task<IActionResult> GetOrderByDateConspects()
      {
        return Ok(await _mediator.Send(new GetConspectsOrderByDate.Query()));
      }

      [Route("conspects/best")]
      [HttpGet]
      public async Task<IActionResult> GetOrderByRatingConspects()
      {
        return Ok(await _mediator.Send(new GetConspectsOrderByDate.Query()));
      }
  }
}