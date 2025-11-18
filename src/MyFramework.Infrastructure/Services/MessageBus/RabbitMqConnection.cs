using RabbitMQ.Client;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.MessageBus
{
    public class RabbitMqConnection
    {
        private readonly RabbitMqSettings _settings;
        private IConnection? _connection;

        public RabbitMqConnection(RabbitMqSettings settings)
        {
            _settings = settings;
        }

        public async Task<IConnection> GetConnection()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _settings.HostName,
                    UserName = _settings.UserName,
                    Password = _settings.Password,
                    
                  //  DispatchConsumersAsync = true
                };
      //          _connection = factory.CreateConnection();
            }
            return _connection;
        }
    }
}
