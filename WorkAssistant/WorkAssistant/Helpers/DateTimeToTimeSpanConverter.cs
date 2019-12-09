using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkAssistant.Helpers
{
    public class DateTimeToTimeSpanConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).TimeOfDay;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var incomingTimeSpan = (TimeSpan)value;
            return new DateTime(2018, 1, 1, incomingTimeSpan.Hours, incomingTimeSpan.Minutes, incomingTimeSpan.Seconds);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
