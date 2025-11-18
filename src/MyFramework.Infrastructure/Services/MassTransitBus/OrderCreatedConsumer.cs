using MassTransit;
using Microsoft.Extensions.Logging;
using MyFramework.Application.Messages.Application.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.MassTransitBus
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly ILogger<OrderCreatedConsumer> _logger;

        public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            var message = context.Message;
            _logger.LogInformation("📥 Received OrderCreated: {OrderId} - {Customer} - {Total:C}",
                message.OrderId, message.CustomerName, message.TotalAmount);

            // You can trigger internal domain logic or persist data here.
            _logger.Log(LogLevel.Information, "message Consumed");
            return Task.CompletedTask;
          
        }
    }
}
