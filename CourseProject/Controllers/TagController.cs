using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseProject.Data.Model;
using CourseProject.Data.Model.Context;
using CourseProject.Web.Api.Tag;
using MediatR;

namespace CourseProject.Web.Api.Controllers
{
    [Route("api/Tag")]
    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetTags.Query()));
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetConpectTags.Query
            {
                ConspectId = id
            }));
        }

        // POST: api/Tag
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] Data.Model.Tag tag)
        {
            return Ok(await _mediator.Send(new CreateTag.Command
            {
                Tag = tag
            }));
        }

        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteTag.Command
            {
                Id = id
            }));
        }
    }
}