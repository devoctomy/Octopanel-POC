using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Octopanel_POC.Core.Converters
{
    public class DateTimeValueConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return ((DateTime)value).ToString("hh:MM:ss dd/mm/yyyy");
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
