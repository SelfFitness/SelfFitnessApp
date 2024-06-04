using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Helpers.Converters
{
    public class ZeroToNullConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var intValue = System.Convert.ToDouble(value);
            if (intValue == 0)
                return null;
            return intValue;
        }
    }
}
