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

namespace GagerApp.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : BaseActivity
    {
        protected override int LayoutResourceId => Resource.Layout.activity_splash;

        private void LaunchLoginActivity()
        {
            _ = Bootstrapper.LaunchFirstActivity();
        }

        protected override void OnResume()
        {
            base.OnResume();
            _ = Task.Run(LaunchLoginActivity);
        }

        protected override object CreateViewModel()
        {
            return null;
        }
    }
}
