using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CourseProject.Api.Services.Rating;
using Microsoft.AspNetCore.Authorization;

namespace CourseProject.Web.Api.Controllers
{
    [Route("api/Rating")]
    public class RatingController : Controller
    {
        private readonly IMediator _mediator;

        public RatingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Rating/2
        [HttpGet("calculateRating/{conspectId}")]
        public async Task<IActionResult> Get([FromRoute] int conspectId)
        {
            return Ok(await _mediator.Send(new CalculateConspectRating.Query
            {
                Id = conspectId
            }));
        }

        [Authorize]
        [HttpPost("rateConspect")]
        public async Task<IActionResult> RateConspect([FromBody] RateConspect.Command command)
        {
          command.ClaimsPrincipal = User;
          return Ok(await _mediator.Send(command));
        }

        [Authorize]
        [HttpPost("canRate")]
        public async Task<IActionResult> CanRateConspect([FromBody] UserRateConspectVerification.Query command)
        {
          command.ClaimsPrincipal = User;
          return Ok(await _mediator.Send(command));
        }
  }
}