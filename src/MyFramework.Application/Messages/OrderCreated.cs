using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Application.Messages
{
    namespace Application.Messages
    {
        public record OrderCreated(Guid OrderId, string CustomerName, decimal TotalAmount):IOrderCreated;
    }
}
