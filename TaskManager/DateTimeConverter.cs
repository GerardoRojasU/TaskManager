using System.Globalization;
using System.Windows.Data;

namespace TaskManager
{
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
