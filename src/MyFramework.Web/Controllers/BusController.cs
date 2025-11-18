using Microsoft.AspNetCore.Mvc;
using MyFramework.Application.Contracts;
using MyFramework.Application.Interfaces;
using MyFramework.Application.Messages.Application.Messages;
using MyFramework.Domain;
using MyFramework.Domain.Entities;
using MyFramework.Infrastructure.Services.MessageBus;

namespace MyFramework.Web.Controllers
{
    [ApiController]
    [Route("api/bus")]
    public class BusController : ControllerBase
    {
        private readonly IMessageBus _messageBus;
        private readonly IEventBus _eventBus;
        private readonly RabbitMqConsumer _rabbitMqConsumer;
        public BusController(IMessageBus messageBus,
            RabbitMqConsumer rabbitMqConsumer,
            IEventBus eventBus)
        {
            _messageBus = messageBus;
            _rabbitMqConsumer = rabbitMqConsumer;
            _eventBus = eventBus;
        }

        [HttpPost("publish")]
        public async Task<IActionResult> Publish([FromBody] EventMessage message)
        {
            await _messageBus.PublishAsync(message);
            return Ok("Message published successfully.");
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            await _rabbitMqConsumer.StartConsuming("myQueue");
            return Ok("Message published successfully.");
        }

        [HttpPost("publishMassTransit")]
        public async Task<IActionResult> publishMassTransit([FromQuery] string customer, [FromQuery] decimal total)
        {
             var message = new OrderCreated(Guid.NewGuid(), customer, total);
           // var message = new OrderCreatedMessage(id, "Ali", 200M);

            await _eventBus.PublishAsync(message);

            return Ok($"Message sent for {message.CustomerName}");
        }
    }
}