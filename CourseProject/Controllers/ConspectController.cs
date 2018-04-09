using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect;
using CourseProject.Api.Services.LookUps;
using CourseProject.Infrastructure.Filter;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CourseProject.Web.Api.Controllers
{
    [ApiExceptionFilterAttribute]
    [Route("api/Conspect")]
    public class ConspectController : Controller
    {
        private readonly IMediator _mediator;

        public ConspectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Conspect
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetConspects.Query()));
        }

        // GET: api/Conspect/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConspect([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetConspect.Query
            {
                Id = id
            }));
        }

        [Route("latest")]
        [HttpGet]
        public async Task<IActionResult> GetSortByDateConspects()
        {
            return Ok(await _mediator.Send(new GetSortByDateConspects.Query()));
        }

        // PUT: api/Conspect/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConspect([FromBody] UpdateConspect.Command command)
        {
            command.UserClaims = User;
            return Ok(await _mediator.Send(command));
        }

        // POST: api/Conspect
        [HttpPost]
        public async Task<IActionResult> CreateConspect([FromBody] CreateConspect.Command command)
        {
            command.UserClaims = User;
            return Ok(await _mediator.Send(command));
        }

        // DELETE: api/Conspect/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConspect([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteConspect.Command
            {
                Id = id
            }));
        }
    }
}