using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Helpers.Converters
{
    public class IntToTimespanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            return ((TimeSpan)value).TotalSeconds;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) 
                return null;
            var seconds = System.Convert.ToDouble(value);
            if (seconds == 0)
                return null;
            return TimeSpan.FromSeconds(seconds);
        }
    }
}
