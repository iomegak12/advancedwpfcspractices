using Alstom.Libraries.Models;
using Alstom.Libraries.UI.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alstom.Libraries.UI.ViewModels.Interfaces
{
    public abstract class BaseCustomersContentViewModel : BaseViewModel
    {
        public string SearchString { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }
        public ICommand Search { get; set; }
        public ICommand Reset { get; set; }
    }
}
