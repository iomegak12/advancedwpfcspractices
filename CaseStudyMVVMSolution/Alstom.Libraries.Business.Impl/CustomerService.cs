using Alstom.Libraries.Business.Interfaces;
using Alstom.Libraries.DAL.Interfaces;
using Alstom.Libraries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.Business.Impl
{
    public class CustomerService : ICustomerService
    {
        private ICustomersContext customersContext = default(ICustomersContext);

        public CustomerService(ICustomersContext customersContext)
        {
            if (customersContext == default(ICustomersContext))
                throw new ArgumentException();

            this.customersContext = customersContext;
        }

        public void Dispose()
        {
            if (this.customersContext != default(ICustomersContext))
                this.customersContext.Dispose();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customersList = default(IEnumerable<Customer>);

            if (this.customersContext != default(ICustomersContext))
                customersList = this.customersContext.Customers.ToList();

            return customersList;
        }

        public Customer GetCustomerDetail(int customerId)
        {
            var filteredCustomer = default(Customer);
            var validation = customerId != default(int) &&
                this.customersContext != default(ICustomersContext);

            if (validation)
            {
                filteredCustomer =
                    this.customersContext
                        .Customers
                        .Where(customer => customer.CustomerId.Equals(customerId))
                        .FirstOrDefault();
            }

            return filteredCustomer;
        }

        public IEnumerable<Customer> SearchCustomers(string customerName)
        {
            var filteredCustomers = default(IEnumerable<Customer>);
            var validation = !string.IsNullOrEmpty(customerName) &&
                this.customersContext != default(ICustomersContext);

            if (validation)
            {
                filteredCustomers =
                    (from customer in customersContext.Customers
                     where customer.CustomerName.Contains(customerName)
                     select customer).ToList();
            }

            return filteredCustomers;
        }
    }
}
