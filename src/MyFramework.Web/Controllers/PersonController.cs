// src/MyFramework.Web/Controllers/PersonController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFramework.Application.Persons.Commands;
using MyFramework.Application.Persons.Queries;
using MyFramework.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyFramework.Web.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Person?>> Get(Guid id)
        {
            var person = await _mediator.Send(new GetPersonQuery(id));
            if (person is null) return NotFound();
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var list = await _mediator.Send(new ListPeopleQuery());
            return Ok(list);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePersonCommand cmd)
        {
            if (id != cmd.Id) return BadRequest();
            await _mediator.Send(cmd);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeletePersonCommand(id));
            return NoContent();
        }
    }
}