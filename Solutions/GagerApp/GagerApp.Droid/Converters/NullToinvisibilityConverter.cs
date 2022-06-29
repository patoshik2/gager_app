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
    /// <summary>
    /// Returns <see cref="ViewStates.Invisible"/> or <see cref="ViewStates.Gone"/> if received value is null, depending on string parameter ("invisible" or "gone" respectively)
    /// </summary>
    public class NullToInvisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string parameterString = parameter as string;
            if (value == null)
            {
                if (parameterString.ToLowerInvariant().Equals("gone"))
                {
                    return ViewStates.Gone;
                }
                return ViewStates.Invisible;
            }
            else
            {
                return ViewStates.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
