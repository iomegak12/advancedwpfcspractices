using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Alstom.Libraries.UI.Extensibility
{
    public class CustomerVideoUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var videoUrl = default(Uri);

            if (value != default(object))
            {
                var customerId = value.ToString();
                var videosBaseFolder = ConfigurationManager.AppSettings["VideosFolder"];

                videoUrl = new Uri(
                    string.Format(@"{0}\Customer ({1}).avi", videosBaseFolder, customerId));
            }

            return videoUrl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
