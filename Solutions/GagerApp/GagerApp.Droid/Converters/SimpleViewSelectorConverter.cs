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
using BindableUI.Droid.Selectors;
using Calcium;
using Calcium.MissingTypes.System.Windows.Data;

namespace GagerApp.Droid.Converters
{
    public class SimpleViewSelectorConverter : IValueConverter
    {
        //A slight optimisation. Most of the selectors are reused througout the code, so we can store them.
        private static readonly Dictionary<int, SimpleViewSelector> KnownSelectors = new Dictionary<int, SimpleViewSelector>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string layoutName = parameter as string;
            if (string.IsNullOrEmpty(layoutName))
            {
                throw new ArgumentException("ConverterParameter must not be empty", nameof(parameter));
            }

            var currentActivity = Dependency.Resolve<Activity>();
            if (currentActivity == null)
            {
                throw new NullReferenceException("Could not obtain current activity. Be sure to register current activity via Dependency.Register<Activity>().");
            }

            var layoutResourceId = currentActivity.Resources.GetIdentifier($"{layoutName.ToLowerInvariant()}", "layout", currentActivity.PackageName);
            //TODO: consider chaecking layoutResourceId

            if (KnownSelectors.ContainsKey(layoutResourceId))
            {
                return KnownSelectors[layoutResourceId];
            }

            var selector = new SimpleViewSelector(layoutResourceId);
            KnownSelectors.Add(layoutResourceId, selector);
            return selector;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
