using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersLibrary
{
    public class DelegateCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<T> action = default(Action<T>);
        private Predicate<T> condition = default(Predicate<T>);

        public DelegateCommand(Action<T> action, Predicate<T> condition = default(Predicate<T>))
        {
            this.action = action;
            this.condition = condition;
        }

        public bool CanExecute(object parameter)
        {
            return this.condition == default(Predicate<T>) ? true :
                this.condition((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}
