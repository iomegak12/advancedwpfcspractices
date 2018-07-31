using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersLibrary
{
    public abstract class BaseCustomerViewModel : BaseModel
    {
        private ObservableCollection<Customer> customers = default(ObservableCollection<Customer>);

        public ICommand Load { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set
            {
                this.customers = value;
                Notify("Customers");
            }
        }
    }
}
