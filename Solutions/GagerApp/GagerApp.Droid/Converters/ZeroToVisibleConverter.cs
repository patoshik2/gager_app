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
    public class ZeroToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            int intvalue = System.Convert.ToInt32(value);
            if (intvalue == 0)
            {
                return ViewStates.Visible;
            }
            return ViewStates.Gone;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
