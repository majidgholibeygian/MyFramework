using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Application.Contracts
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T message) where T : class;
    }
}
