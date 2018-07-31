using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsLibrary
{
    public class LoadCustomersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var customers = parameter as Customers;

            if (customers != default(Customers))
            {
                var customerService = new CustomerService();
                var customersList = customerService.GetCustomers();

                customers.Clear();

                foreach (var customer in customersList)
                    customers.Add(customer);
            }
        }
    }
}
