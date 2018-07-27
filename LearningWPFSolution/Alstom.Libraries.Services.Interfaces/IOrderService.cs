using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(int customerId);
    }
}
