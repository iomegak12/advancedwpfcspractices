using System.Collections.Generic;

namespace CustomersLibrary
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
    }
}
