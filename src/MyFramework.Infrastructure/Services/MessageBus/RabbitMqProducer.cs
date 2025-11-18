using MyFramework.Application.Interfaces;
using MyFramework.Domain.Entities;
using MyFramework.Infrastructure.Services.MessageBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Infrastructure.MessageBus
{
    public class RabbitMqProducer : IMessageBus
    {
        private readonly RabbitMqSettings _settings;
        private readonly RabbitMqConnection _connection;

        public RabbitMqProducer(RabbitMqSettings settings, RabbitMqConnection connection)
        {
            _settings = settings;
            _connection = connection;
        }

        // تغییر امضا متد به async Task
        public async Task PublishAsync(EventMessage message)
        {
            //var connection = await _connection.GetConnection();

            //using var channel = connection.CreateModel();
            //channel.ExchangeDeclare(_settings.ExchangeName, ExchangeType.Fanout, durable: true);

            //var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            //channel.BasicPublish(exchange: _settings.ExchangeName, routingKey: "", basicProperties: null, body: body );

         
        }

        public async Task SubscribeAsync(string queueName)
        {
            // برای این کلاس، Subscribing استفاده نمی‌شود
            await Task.CompletedTask;
        }
    }
}
