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
    public class CustomerPhotoUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var photoUrl = default(Uri);

            if (value != default(object))
            {
                var customerId = value.ToString();
                var photosBaseFolder = ConfigurationManager.AppSettings["PhotosFolder"];

                photoUrl = new Uri(
                    string.Format(@"{0}\Customer{1}.jpg", photosBaseFolder, customerId));
            }

            return photoUrl;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
