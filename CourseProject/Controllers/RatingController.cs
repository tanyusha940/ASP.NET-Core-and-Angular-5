using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Rating;
using MediatR;

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

        // GET: api/Rating/5
        [HttpGet("conspectRating/{conspectId}/{userId}")]
        public async Task<IActionResult> GetRating([FromRoute] int conspectId, string userId)
        {
            return Ok(await _mediator.Send(new GetRating.Query
            {
                UserId = userId,
                ConspectId = conspectId
            }));
        }

        // POST: api/Rating
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromBody] CreateRating.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        // DELETE: api/Rating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteRating.Command
            {
                ConspectId = id
            }));
        }
    }
}