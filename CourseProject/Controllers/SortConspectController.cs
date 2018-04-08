using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect;
using CourseProject.Api.Services.LookUps;
using CourseProject.Infrastructure.Filter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseProject.Web.Api.Controllers
{
    [ApiExceptionFilter]
    [Route("api/[controller]/[action]")]
    public class SortConspectController : Controller
    {
        private readonly IMediator _mediator;

        public SortConspectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetSortByDateConspects()
        {
            return Ok(await _mediator.Send(new GetSortByDateConspects.Query()));
        }
        [HttpGet]
        public async Task<IActionResult> GetSortByRatingConspects()
        {
            return Ok(await _mediator.Send(new GetSortByRatingConspects.Query()));
        }
    }
}