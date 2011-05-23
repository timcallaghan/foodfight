using System.Windows.Data;
using System.Globalization;
using System;

namespace FoodFightSilverlightClient.Converters
{
    public class NullableTimespanConverter : IValueConverter
    {
        public object Convert
        (
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                TimeSpan Time = (TimeSpan)value;
                return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Time.Hours, Time.Minutes, Time.Seconds);
                //return value;
            }
        }

        public object ConvertBack
        (
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            if
            (
                value == null
                ||
                String.IsNullOrEmpty(value.ToString())
            )
            {
                return null;
            }
            else
            {
                DateTime SelectedDateTime = (DateTime)value;
                return SelectedDateTime.TimeOfDay;
            }
        }
    }
}
