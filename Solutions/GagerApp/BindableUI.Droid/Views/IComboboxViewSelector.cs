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

namespace BindableUI.Droid.Views
{
    public interface IComboboxViewSelector : IViewSelector
    {
        /// <summary>
        /// A total view types possibly returned by selector
        /// </summary>
        int ViewTypeCount
        {
            get;
        }

        /// <summary>
        /// A view type (not to be confused with <see cref="IViewSelector.GetLayoutResourceId(object)"/>)
        /// </summary>
        /// <param name="viewModel">Must be in range of [0..<see cref="ViewTypeCount"/>-1]</param>
        /// <returns></returns>
        int GetItemViewType(object viewModel);

        /// <summary>
        /// A resource to be displayed for selected item.
        /// There are possibilities when selected item should be clickable, but dropdown items should not be clickable.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        int GetSelectedItemLayoutResourceId(object viewModel);
    }
}
