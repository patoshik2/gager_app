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

namespace GagerApp.Droid.Converters
{
    public class TrueToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool sourceValue;
            if (value == null)
            {
                sourceValue = false;
            }
            else
            {
                sourceValue = System.Convert.ToBoolean(value);
            }

            if (sourceValue)
            {
                return ViewStates.Visible;
            }
            return ViewStates.Gone;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool sourceValue;
            ViewStates viewStates = (ViewStates)value;

            if (viewStates == ViewStates.Visible)
            {
                sourceValue = true;
            }
            else
            {
                sourceValue = false;
            }
            return sourceValue;
        }
    }
}
