using System;
using System.Globalization;
using Xamarin.Forms;

namespace BeerDrinking.Converters
{
    public class DateTimeToYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var offset = (DateTimeOffset)value;
            return offset.Year.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var year = int.Parse(value.ToString());
                return new DateTime(year, 1, 1);
            }
            catch (Exception ex)
            {
                return default(DateTimeOffset);
            }
        }
    }
}
