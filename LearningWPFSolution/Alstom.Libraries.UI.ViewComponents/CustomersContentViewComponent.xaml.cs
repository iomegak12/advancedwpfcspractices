using Alstom.Libraries.Models;
using Alstom.Libraries.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alstom.Libraries.UI.ViewComponents
{
    /// <summary>
    /// Interaction logic for HomeContentViewComponent.xaml
    /// </summary>
    public partial class CustomersContentViewComponent : UserControl
    {
        public CustomersContentViewComponent()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var customerService = new CustomerService();
            var searchResult = customerService.GetCustomers(this.txtSearchString.Text);

            this.lbCustomers.DisplayMemberPath = "Name";
            this.lbCustomers.ItemsSource = searchResult;

        }

        private void HandleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = this.lbCustomers.SelectedItem as Customer;

            DisplayData(selectedCustomer);
        }

        private void DisplayData(Customer selectedCustomer)
        {
            if (selectedCustomer != default(Customer))
            {
                this.txtCustomerId.Text = selectedCustomer.Id.ToString();
                this.txtCustomerName.Text = selectedCustomer.Name;
                this.txtBusinessAddress.Text = selectedCustomer.Address;
                this.txtCreditLimit.Text = selectedCustomer.Credit.ToString("C");
                this.chkActiveStatus.IsChecked = selectedCustomer.Status;
                this.imgEmployee.Source = new BitmapImage(
                    new Uri(selectedCustomer.PhotoUrl));
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.txtSearchString.Text = string.Empty;
            this.lbCustomers.ItemsSource = default(IEnumerable<Customer>);
            this.txtCustomerId.Text =
                this.txtCustomerName.Text =
                this.txtBusinessAddress.Text =
                this.txtCreditLimit.Text = string.Empty;
            this.chkActiveStatus.IsChecked = default(bool);
            this.imgEmployee.Source = default(ImageSource);
        }
    }
}
