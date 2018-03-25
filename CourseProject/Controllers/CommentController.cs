using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Web.Api.Comment;
using MediatR;

namespace CourseProject.Web.Api.Controllers
{
    [Route("api/Comment")]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetComments.Query()));
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetComment.Query
            {
                Id = id
            }));
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateComment.Command command)
        {
            return Ok(await _mediator.Send(command));
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteComment.Command
            {
                ConspectId = id
            }));
        }
    }
}