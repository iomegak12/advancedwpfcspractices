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
    public abstract class BaseMainViewModel : BaseViewModel
    {
        #region Commands

        private ObservableCollection<Customer> customers = default(ObservableCollection<Customer>);

        public ObservableCollection<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; Notify("Customers"); }
        }

        private string searchString;

        public string SearchString
        {
            get { return this.searchString; }
            set { this.searchString = value; Notify("SearchString"); }
        }

        #endregion

        #region Properties

        public ICommand Help { get; protected set; }
        public ICommand Close { get; protected set; }
        public ICommand Search { get; protected set; }
        public ICommand Reset { get; protected set; }
        public ICommand Sort { get; protected set; }

        #endregion
    }
}
