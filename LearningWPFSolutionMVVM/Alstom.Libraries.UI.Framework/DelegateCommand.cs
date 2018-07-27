using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alstom.Libraries.UI.Framework
{
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> action = default(Action<T>);
        private Predicate<T> condition = default(Predicate<T>);

        public DelegateCommand(Action<T> action, Predicate<T> condition = default(Predicate<T>))
        {
            this.action = action;
            this.condition = condition;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.condition == default(Predicate<T>) ? true : this.condition((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}
