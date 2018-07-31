using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomerLibrary
{
    public class ShowCreditCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var customer = parameter as Customer;

            if (customer != default(Customer))
            {
                var creditLimit = new Random().Next(10000, 50000);

                customer.CreditLimit = creditLimit;
            }
        }
    }
}
