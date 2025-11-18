using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFramework.Application.Messages
{
    public interface IOrderCreated
    {
        Guid OrderId { get; }
        string CustomerName { get; }
        decimal TotalAmount { get; }
    }
}
