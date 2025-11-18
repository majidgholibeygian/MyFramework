using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.MessageBus
{
    public class RabbitMqConsumer
    {
        private readonly RabbitMqSettings _settings;
        private readonly RabbitMqConnection _connection;

        public RabbitMqConsumer(RabbitMqSettings settings, RabbitMqConnection connection)
        {
            _settings = settings;
            _connection = connection;
        }

        public async Task StartConsuming(string queueName)
        {
            //var connection = await _connection.GetConnection();

            //using var channel = connection.CreateModel();
            //channel.ExchangeDeclare(_settings.ExchangeName, ExchangeType.Fanout, durable: true);
            //channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false);
            //channel.QueueBind(queueName, _settings.ExchangeName, "");

            //var consumer = new AsyncEventingBasicConsumer(channel);
            //consumer.Received += async (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = JsonSerializer.Deserialize<Domain.Entities.EventMessage>(Encoding.UTF8.GetString(body))!;
            //    Console.WriteLine($"[Received] {message.EventName} => {message.Payload}");
            //    await Task.Yield();
            //};

            //channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            //Console.WriteLine($"Consumer started on queue '{queueName}'");
        }
    }
}
