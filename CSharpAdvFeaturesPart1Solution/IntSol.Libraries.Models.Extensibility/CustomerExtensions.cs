using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntSol.Libraries.Models.Extensibility
{
    public static class CustomerExtensions
    {
        public static string GetLicenseKey(this Customer customer)
        {
            var licenseKey = default(string);

            if (customer == default(Customer))
                throw new ArgumentException();

            licenseKey = string.Format(@"{0}-{1}",
                Guid.NewGuid().ToString(), customer.CustomerId);

            return licenseKey;
        }
    }
}
