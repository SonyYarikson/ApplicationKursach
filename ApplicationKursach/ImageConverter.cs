using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ApplicationKursach
{
    public class NullToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new BitmapImage(new Uri("C:/Users/yaros/OneDrive/Рабочий стол/курсач/img/default.png", UriKind.Relative));
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
