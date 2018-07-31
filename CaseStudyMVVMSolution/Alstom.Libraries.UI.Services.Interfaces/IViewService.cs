using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alstom.Libraries.UI.Services.Interfaces
{
    public interface IViewService
    {
        void NavigateTo(string viewName, bool isViewModelAvailable = default(bool));
    }
}
