using Alstom.Libraries.UI.Framework;
using Alstom.Libraries.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alstom.Libraries.UI.Services.Impl
{
    public class WPFViewService : IViewService
    {
        public void NavigateTo(string viewName, bool isViewModelAvailable = false)
        {
            if (string.IsNullOrEmpty(viewName))
                throw new ArgumentException();

            var viewObject = ViewBuilder.Build<Window>(viewName, isViewModelAvailable);

            if (viewObject != default(Window))
                viewObject.Show();
        }
    }
}
