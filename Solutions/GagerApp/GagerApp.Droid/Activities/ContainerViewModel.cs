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
using AndroidX.Lifecycle;

namespace GagerApp.Droid.Activities
{
    public class ContainerViewModel : ViewModel
    {
        private object _viewModel;

        public object GetViewModel(Func<object> createViewModel)
        {
            if (_viewModel is null)
            {
                _viewModel = createViewModel();
            }

            return _viewModel;
        }
    }
}
