using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LearningDepProps
{
    public class SliderValueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = default(SolidColorBrush);

            if (value != default(object))
            {
                var convertedValue = double.Parse(value.ToString());

                if (convertedValue >= 1 && convertedValue < 40)
                {
                    color = new SolidColorBrush(Colors.Red);
                }
                else if (convertedValue >= 40 && convertedValue < 70)
                {
                    color = new SolidColorBrush(Colors.Yellow);
                }
                else color = new SolidColorBrush(Colors.Green);
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
