using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CommandsLibrary
{
    public class CustomerInfoMVConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var customerOrderInfo = default(CustomerOrderInfo);

            if (values != default(object[]))
            {
                customerOrderInfo = new CustomerOrderInfo
                {
                    SelectedCustomer = values[0] as Customer,
                    Orders = values[1] as Orders
                };
            }

            return customerOrderInfo;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
