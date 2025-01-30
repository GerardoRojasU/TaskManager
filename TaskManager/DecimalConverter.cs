using System.Globalization;
using System.Windows.Data;

namespace TaskManager
{
    [ValueConversion(typeof(double), typeof(String))]
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return double.Parse(value.ToString(), CultureInfo.InvariantCulture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
