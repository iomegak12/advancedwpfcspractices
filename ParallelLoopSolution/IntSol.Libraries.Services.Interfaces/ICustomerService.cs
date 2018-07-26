using IntSol.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
    }
}
