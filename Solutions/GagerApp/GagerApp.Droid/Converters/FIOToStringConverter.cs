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
using GagerApp.Model.DTO;

namespace GagerApp.Droid.Converters
{
    public class FIOToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            ClientDTO client = value as ClientDTO;
            return client.SurnameClient + " " + client.NameClient + " " + client.PaternumClient;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
