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
    public class StatusVisibleForGoToZamerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ViewStates.Gone;
            }

            OrderStatus status = (OrderStatus)value;
            return status == OrderStatus.Confirmed|| status == OrderStatus.Rejected ? ViewStates.Gone : (object)ViewStates.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
