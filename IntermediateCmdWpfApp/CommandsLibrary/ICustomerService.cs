using System.Collections.Generic;

namespace CommandsLibrary
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers(string customerName = default(string));
    }
}
