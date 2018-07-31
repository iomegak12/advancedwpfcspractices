using Alstom.Libraries.Business.Interfaces;
using Alstom.Libraries.Models;
using Alstom.Libraries.UI.Framework;
using Alstom.Libraries.UI.Services.Interfaces;
using Alstom.Libraries.UI.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Alstom.Libraries.UI.ViewModels.Impl
{
    public class MainViewModel : BaseMainViewModel
    {
        private ICustomerService customerService = default(ICustomerService);
        private IApplicationService applicationService = default(IApplicationService);
        private IViewService viewService = default(IViewService);

        public MainViewModel(ICustomerService customerService,
            IApplicationService applicationService, IViewService viewService)
        {
            var validation = customerService != default(ICustomerService) &&
                applicationService != default(IApplicationService) &&
                viewService != default(IViewService);

            if (!validation)
                throw new ArgumentException();

            this.customerService = customerService;
            this.applicationService = applicationService;
            this.viewService = viewService;

            #region Search Command Implementation

            this.Search = new DelegateCommand<string>(
                searchString =>
                {
                    var customersList = default(IEnumerable<Customer>);

                    if (string.IsNullOrEmpty(searchString) || searchString.Equals("*"))
                    {
                        customersList = this.customerService.GetAllCustomers();
                    }
                    else
                    {
                        customersList = this.customerService.SearchCustomers(searchString);
                    }

                    this.Customers = new ObservableCollection<Customer>(customersList);
                });

            #endregion

            #region Reset Command Implementation

            this.Reset = new DelegateCommand<object>(
                parameter =>
                {
                    this.SearchString = string.Empty;
                    this.Customers = default(ObservableCollection<Customer>);
                });

            #endregion

            #region Sort Command Implementation

            this.Sort = new DelegateCommand<object>(
                parameter =>
                {
                    var collectionView = CollectionViewSource.GetDefaultView(this.Customers);

                    collectionView.SortDescriptions.Add(
                        new SortDescription("CustomerName", ListSortDirection.Ascending));
                });

            #endregion

            #region Close Command Implementation

            this.Close = new DelegateCommand<object>(
                parameter =>
                {
                    this.applicationService.Shutdown();
                });

            #endregion

            #region Help Command Implementation

            this.Help = new DelegateCommand<string>(
                viewName =>
                {
                    if (!string.IsNullOrEmpty(viewName))
                    {
                        this.viewService.NavigateTo(viewName);
                    }
                });

            #endregion
        }
    }
}
