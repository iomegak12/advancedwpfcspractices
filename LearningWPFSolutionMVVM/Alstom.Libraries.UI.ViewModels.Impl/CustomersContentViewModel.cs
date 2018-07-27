using Alstom.Libraries.Models;
using Alstom.Libraries.Services.Impl;
using Alstom.Libraries.Services.Interfaces;
using Alstom.Libraries.UI.Framework;
using Alstom.Libraries.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.UI.ViewModels.Impl
{
    public class CustomersContentViewModel : BaseCustomersContentViewModel
    {
        private ICustomerService customerService = default(ICustomerService);

        public CustomersContentViewModel()
        {
            this.customerService = new CustomerService();

            this.Search = new DelegateCommand<string>(
                searchString =>
                {
                    this.Customers = new ObservableCollection<Customer>(
                        this.customerService.GetCustomers(searchString));

                    Notify("Customers");
                });

            this.Reset = new DelegateCommand<object>(
                parameter =>
                {
                    this.Customers = default(ObservableCollection<Customer>);
                    this.SearchString = string.Empty;

                    Notify("Customers", "SearchString");
                });
        }
    }
}
