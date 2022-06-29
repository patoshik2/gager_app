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
using GagerApp.Core;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Dialogs;
using GagerApp.Droid.Activities;

namespace GagerApp.Droid.Services
{
    public class DialogService : IDialogService
    {
        private static readonly Dictionary<Type, int> DialogsLayoutDictionary = new Dictionary<Type, int>()
        {
            { typeof(AddNewRoomDialogViewModel), Resource.Layout.dialog_single_text_input},
            {typeof(DeleteRoomDialogViewModel), Resource.Layout.dialog_delete_room}
        };

        public void ShowDialog(string dialogKey, object param = null)
        {
            Type viewModelType = NavigationDictionary.ResolveType(dialogKey);

            Activity currentActivity = Dependency.Resolve<Activity>();

            _ = CommonDialogFragment.ShowDialog<CommonDialogFragment>(currentActivity as AndroidX.Fragment.App.FragmentActivity, DialogsLayoutDictionary[viewModelType], viewModelType, param);

            //TODO: do something with returned fragment?
        }
    }
}
