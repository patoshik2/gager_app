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
using BindableUI.Droid.Views;

namespace BindableUI.Droid.Selectors
{
    public class SimpleViewSelector : IComboboxViewSelector, IViewSelector
    {
        private readonly int _resourceId;

        public SimpleViewSelector(int resourceId)
        {
            _resourceId = resourceId;
        }

        public int ViewTypeCount => 1;

        public int GetItemViewType(object viewModel)
        {
            return 0;
        }

        public int GetLayoutResourceId(object obj)
        {
            return _resourceId;
        }

        public int GetSelectedItemLayoutResourceId(object viewModel)
        {
            return GetLayoutResourceId(viewModel);
        }
    }
}
