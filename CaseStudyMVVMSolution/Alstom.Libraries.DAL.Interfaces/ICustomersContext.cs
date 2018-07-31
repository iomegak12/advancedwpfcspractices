using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.DAL.Interfaces
{
    public interface ICustomersContext : IDisposable
    {
        IDbSet<Customer> Customers { get; set; }
    }
}
