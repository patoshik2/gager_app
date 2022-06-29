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
using Calcium;
using Java.Sql;

namespace GagerApp.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class StandardPageActivity : BaseActivity        
    {
        #region Fields

        public static readonly string EncodedViewModelTypeKey = nameof(StandardPageActivity) + "." + nameof(EncodedViewModelTypeKey);
        public static readonly string LayoutResourceIDKey = nameof(StandardPageActivity) + "." + nameof(LayoutResourceIDKey);

        #endregion Fields

        #region Properties/Indexers

        protected sealed override int LayoutResourceId
        {
            get
            {
                var layoutResourceID = Intent.GetIntExtra(LayoutResourceIDKey, int.MinValue);
                if (layoutResourceID == int.MinValue)
                {
                    throw new ArgumentException("No layout resource id was passed in Intent.");
                }
                return layoutResourceID;
            }
        }

        #endregion Properties/Indexers

        #region Methods/Events

        public static string EncodeViewModelType(Type viewModelType)
        {
            return viewModelType.AssemblyQualifiedName;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void SetContentView(View view)
        {
            base.SetContentView(view);

            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.system_action_bar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);

                if (!IsTaskRoot)
                {
                    SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                }                
            }
        }

        protected sealed override object CreateViewModel()
        {
            string typeString = Intent.GetStringExtra(EncodedViewModelTypeKey);

            if (string.IsNullOrEmpty(typeString))
            {
                throw new ArgumentException("No view model type name was passed in Intent.");
            }
            Type viewModelType = DecodeViewModelType(typeString);
            object viewModel = Dependency.ResolveWithType(viewModelType);

            return viewModel;
        }

        private Type DecodeViewModelType(string encodedType)
        {
            return Type.GetType(encodedType);
        }

        #endregion Methods/Events
    }
}
