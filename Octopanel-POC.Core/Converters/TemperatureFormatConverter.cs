using Avalonia.Data.Converters;
using Octopanel_POC.Core.Octoprint.Model;
using System;
using System.Globalization;

namespace Octopanel_POC.Core.Converters
{
    public class TemperatureFormatConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return String.Format("{0:0.00}°c", value);
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
