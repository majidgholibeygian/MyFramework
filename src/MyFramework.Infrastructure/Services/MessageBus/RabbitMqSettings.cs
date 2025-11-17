using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Infrastructure.Services.MessageBus
{
    public class RabbitMqSettings
    {
        public string HostName { get; set; } = "localhost";
        public string UserName { get; set; } = "quest";
        public string Password { get; set; } = "quest";
        public string ExchangeName { get; set; } = "main_exchange";
    }
}
