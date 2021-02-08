using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DemoTest.Classes
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "информация отсутствует";
            }

            int seconds = int.Parse(value.ToString());

            if (seconds > 60 && seconds < 3600)
            {
                return (seconds / 60 + " минут");
            }
            else if (seconds > 3600 && seconds < 7200)
            {
                return (seconds / 3600 + " h " + (seconds / 60 - 60) + " m");
            }
            else if (seconds > 7200 && seconds < 14400)
            {
                return (seconds / 3600 + " Часа " + (seconds / 60 - 120) + " минут");
            }

            return seconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
