using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsLibrary
{
    public class LoadOrdersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var customerOrderInfo = parameter as CustomerOrderInfo;

            if (customerOrderInfo != default(CustomerOrderInfo))
            {
                var selectedCustomer = customerOrderInfo.SelectedCustomer;
                var orders = customerOrderInfo.Orders;
                var orderService = new OrderService();
                var ordersList = orderService.GetOrders(selectedCustomer.Id);

                orders.Clear();

                foreach (var order in ordersList)
                    orders.Add(order);
            }
        }
    }
}
