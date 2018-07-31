using Alstom.Libraries.DI.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alstom.Libraries.UI.Framework
{
    public static class ViewBuilder
    {
        public static T Build<T>(string viewName,
            bool isViewModelAvailable = default(bool)) where T : FrameworkElement
        {
            var viewObject = default(Window);

            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException();

            viewObject = AlstomObjectBuilder.Instance.GetObject<Window>(viewName);

            if (isViewModelAvailable)
            {
                var viewModelName = string.Format(@"{0}Model", viewName);
                var viewModel = AlstomObjectBuilder.Instance.GetObject<BaseViewModel>(viewModelName);

                viewObject.DataContext = viewModel;
            }

            return viewObject as T;
        }
    }
}
