using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Lifecycle;
using Calcium.UI.Data;

namespace GagerApp.Droid.Activities
{
    public abstract class BaseDialogFragment : AndroidX.Fragment.App.DialogFragment
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

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public sealed override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var contentView = inflater.Inflate(LayoutResourceId, container, false);

            _bindingApplicator.ApplyBindings(contentView, GetViewModel(), LayoutResourceId);

            return contentView;
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            _bindingApplicator.RemoveBindings();
        }

        /// <summary>
        /// Create ViewModel for this activity
        /// </summary>
        /// <returns>Created ViewModel</returns>
        protected abstract object CreateViewModel();

        protected object GetViewModel()
        {
            ContainerViewModel activityViewModel = new ViewModelProvider(this).Get(Java.Lang.Class.FromType(typeof(ContainerViewModel))) as ContainerViewModel;
            return activityViewModel.GetViewModel(CreateViewModel);
        }

        #endregion Methods/Events


    }
}
