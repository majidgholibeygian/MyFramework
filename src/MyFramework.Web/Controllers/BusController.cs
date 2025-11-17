using Microsoft.AspNetCore.Mvc;
using MyFramework.Application.Interfaces;
using MyFramework.Domain.Entities;

namespace MyFramework.Web.Controllers
{
    [ApiController]
    [Route("api/bus")]
    public class BusController : ControllerBase
    {
        private readonly IMessageBus _messageBus;

        public BusController(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish([FromBody] EventMessage message)
        {
            await _messageBus.PublishAsync(message);
            return Ok("Message published successfully.");
        }
    }
}