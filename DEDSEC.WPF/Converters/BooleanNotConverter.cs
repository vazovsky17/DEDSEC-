using System;
using System.Globalization;
using System.Windows.Data;

namespace DEDSEC.WPF.Converters
{
    public class BooleanNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valBool)
                return !valBool;
            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valBool)
                return !valBool;
            throw new ArgumentException();
        }
    }
}
