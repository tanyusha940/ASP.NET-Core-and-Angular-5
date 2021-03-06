﻿using System;
using System.Threading.Tasks;
using CourseProject.Api.Services.Conspect;
using CourseProject.Infrastructure.Filter;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CourseProject.Web.Api.Controllers
{
    [Authorize]
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

        [Route("api/Conspect/[action]")]
        [HttpGet]
        public async Task<IActionResult> GetSortByDateConspects()
        {
            return Ok(await _mediator.Send(new GetSortByDateConspects.Query()));
        }

        // PUT: api/Conspect/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConspect([FromRoute] int id, [FromBody] Data.Model.Conspect conspect)
        {
            if (id != conspect.Id)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new UpdateConspect.Command
            {
                Conspect = conspect
            }));
        }

        // POST: api/Conspect
        [HttpPost]
        public async Task<IActionResult> CreateConspect([FromBody] CreateConspect.Command command)
        {
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