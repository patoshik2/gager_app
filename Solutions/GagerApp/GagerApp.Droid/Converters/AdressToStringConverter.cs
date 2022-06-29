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
    public class AdressToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            AdressDTO adress = value as AdressDTO;
            if (adress == null)
                return string.Empty;
            else if (adress.NumberKvartira == null)
                return adress.Burg + ", " + adress.Ulica + ", Д." + adress.NumberDom;
            else
                return adress.Burg +", " + adress.Ulica +", Д."+ adress.NumberDom + ", " + adress.NumberKvartira  ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
