using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Lifecycle;
using Calcium;
using Calcium.UI.Data;

namespace GagerApp.Droid.Activities
{
    public abstract class BaseActivity : AppCompatActivity
    {
        #region Fields

        private readonly XmlBindingApplicator _bindingApplicator = new XmlBindingApplicator();

        #endregion Fields

        #region Properties/Indexers

        /// <summary>
        /// The layout to be inflated and shown to user
        /// </summary>
        protected abstract int LayoutResourceId
        {
            get;
        }

        #endregion Properties/Indexers

        #region Methods/Events

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// Create ViewModel for this activity
        /// </summary>
        /// <returns>Created ViewModel</returns>
        protected abstract object CreateViewModel();

        protected sealed override void OnCreate(Bundle savedInstanceState)
        {
            Bootstrapper.Init();
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here

            var contentView = View.Inflate(this, LayoutResourceId, null);
            SetContentView(contentView);

            _bindingApplicator.ApplyBindings(contentView, GetViewModel(), LayoutResourceId);      
        }

        protected sealed override void OnDestroy()
        {
            base.OnDestroy();
            _bindingApplicator.RemoveBindings();
        }

        protected override void OnResume()
        {
            base.OnResume();

            Dependency.Register<Activity>(this);
        }

        private object GetViewModel()
        {
            ContainerViewModel activityViewModel = new ViewModelProvider(this).Get(Java.Lang.Class.FromType(typeof(ContainerViewModel))) as ContainerViewModel;
            return activityViewModel.GetViewModel(CreateViewModel);
        }

        #endregion Methods/Events
    }
}
