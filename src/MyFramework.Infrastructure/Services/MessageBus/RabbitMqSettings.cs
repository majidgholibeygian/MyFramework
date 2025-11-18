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
        public string UserName { get; set; } = "admin";
        public string Password { get; set; } = "admin@123";
        public string ExchangeName { get; set; } = "main_exchange";
    }
}
