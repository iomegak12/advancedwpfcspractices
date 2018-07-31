using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.UI.Framework
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Notify(params string[] properties)
        {
            foreach (var property in properties)
            {
                if (PropertyChanged != default(PropertyChangedEventHandler))
                    PropertyChanged(
                        this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
