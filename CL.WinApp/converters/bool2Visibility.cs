using System;
using System.Globalization;
using System.Windows.Data;

namespace CL.WinApp.converters
{
    public class bool2Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? val = value as bool?;
            if (val == null) return null;
            if (parameter as string == "inverse") val = !val;
            if (val == true) return "Visible";
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
