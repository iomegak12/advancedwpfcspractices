using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Business.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<Customer> SearchCustomers(string customerName);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerDetail(int customerId);
    }
}
