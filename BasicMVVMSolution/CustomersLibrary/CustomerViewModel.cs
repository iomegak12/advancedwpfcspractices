using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersLibrary
{
    public class CustomerViewModel : BaseCustomerViewModel
    {
        private ICustomerService customerService = default(ICustomerService);

        public CustomerViewModel()
        {
            this.customerService = new CustomerService();

            this.Load = new DelegateCommand<object>(
                parameter =>
                {
                    var customersList = this.customerService.GetCustomers();

                    this.Customers = new ObservableCollection<Customer>(customersList);
                });
        }
    }
}
