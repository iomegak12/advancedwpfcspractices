using System.Collections.Generic;

namespace CommandsLibrary
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(int customerId);
    }
}
