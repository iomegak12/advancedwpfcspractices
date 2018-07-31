using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Alstom.Libraries.UI.Extensibility
{
    public class ActiveStatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = default(SolidColorBrush);

            if (value != default(object))
            {
                var activeStatus = bool.Parse(value.ToString());

                if (activeStatus)
                    brush = new SolidColorBrush(Colors.Green);
                else brush = new SolidColorBrush(Colors.Red);
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
