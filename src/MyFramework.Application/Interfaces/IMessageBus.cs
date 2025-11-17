using MyFramework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Application.Interfaces
{
    public interface IMessageBus
    {
        Task PublishAsync(EventMessage message);
        Task SubscribeAsync(string queueName);
    }
}
