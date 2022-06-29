using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calcium;
using GagerApp.Core.Services;
using Google.Android.Material.Snackbar;
using Xamarin.Essentials;

namespace GagerApp.Droid.Services
{
    public class PlatformService : IPlatformService
    {
        public void CallPhone(string phone)
        {            
            try
            {
                PhoneDialer.Open(phone);
            }
            catch (ArgumentNullException)
            {
                var currentActivity = Dependency.Resolve<Activity>();
                if (currentActivity is null)
                {
                    throw new ArgumentException($"Current activity not found. Use {nameof(Dependency)}.{nameof(Dependency.Register)} to register activity.");
                }
                var activityRootView = currentActivity.FindViewById<ViewGroup>(Resource.Id.content).GetChildAt(0);

                Snackbar.Make(activityRootView, "Неверный номер.", Snackbar.LengthShort).Show();
            }
            catch (FeatureNotSupportedException)
            {
                var currentActivity = Dependency.Resolve<Activity>();
                if (currentActivity is null)
                {
                    throw new ArgumentException($"Current activity not found. Use {nameof(Dependency)}.{nameof(Dependency.Register)} to register activity.");
                }
                var activityRootView = currentActivity.FindViewById<ViewGroup>(Resource.Id.content).GetChildAt(0);
                Snackbar.Make(activityRootView, "Данное устройство не поддерживает голосовые вызовы.", Snackbar.LengthShort).Show();
            }

        }
    }
}
