using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calcium.MissingTypes.System.Windows.Data;
using GagerApp.Model.Entities;

namespace GagerApp.Droid.Converters
{
    public class OrderPageStatusZamerToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OrderPageStatusZamer orderPageStatusZamer = (OrderPageStatusZamer)value;
            return orderPageStatusZamer.Translate();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
