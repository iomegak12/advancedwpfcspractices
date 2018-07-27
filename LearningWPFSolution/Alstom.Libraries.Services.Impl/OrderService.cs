using Alstom.Libraries.Models;
using Alstom.Libraries.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Services.Impl
{
    public class OrderService : IOrderService
    {
        public IEnumerable<Order> GetOrders(int customerId)
        {
            var random = new Random();
            var ordersList = new List<Order>(
                from index in Enumerable.Range(5, 10)
                select new Order
                {
                    OrderId = random.Next(1, 1000000),
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                    Amount = random.Next(10000, 50000)
                });

            return ordersList;
        }
    }
}
