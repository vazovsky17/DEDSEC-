using System;
using System.Globalization;
using System.Windows.Data;

namespace DEDSEC.WPF.Converters
{
    internal class YesOrNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valBool)
                if (valBool)
                {
                    return "Да";
                }
                else
                {
                    return "Нет";
                }
            throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new ArgumentException();
        }
    }
}
