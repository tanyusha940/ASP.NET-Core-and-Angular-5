using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CourseProject.Web.Api.Conspect;

namespace CourseProject.Web.Api.Controllers
{
    [Route("api/Conspects")]
    public class ConspectsController : Controller
    {
        private readonly IMediator _mediator;

        public ConspectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Conspects
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetConspects.Query()));
        }

        // GET: api/Conspects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConspect([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(new GetConspect.Query
            {
                Id = id
            }));
        }

        // PUT: api/Conspects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConspect([FromRoute] int id, [FromBody] Data.Model.Conspect conspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conspect.Id)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new UpdateConspect.Command
            {
                Conspect = conspect
            }));
        }

        // POST: api/Conspects
        [HttpPost]
        public async Task<IActionResult> CreateConspect([FromBody] Data.Model.Conspect conspect)
        {
            return Ok(await _mediator.Send(new CreateConspect.Command
            {
                Conspect = conspect
            }));
        }

        // DELETE: api/Conspects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConspect([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new DeleteConspect.Command
            {
                Id = Id
            }));
        }
    }
}