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
using Calcium.Navigation;
using Calcium.Services;
using GagerApp.Core;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel;
using GagerApp.Core.ViewModel.Pages;
using GagerApp.Droid.Activities;
using GagerApp.Droid.Services;
using GagerApp.Model.Entities;

namespace GagerApp.Droid
{
    internal static class Bootstrapper
    {
        #region Fields

        private static readonly Dictionary<Type, int> PagesLayoutDictionary = new Dictionary<Type, int>()
        {
            { typeof(LoginPageViewModel), Resource.Layout.activity_login },
            { typeof(RootPageViewModel), Resource.Layout.activity_rootpage },
            { typeof(OrderPageViewModel), Resource.Layout.activity_order },
            {typeof(ZamerPageViewModel), Resource.Layout.activity_zamer },
            {typeof(RoomPageViewModel), Resource.Layout.activity_room },
        };

        private static bool Initialized = false;

        #endregion Fields

        #region Methods/Events

        internal static void Init()
        {
            if (Initialized)
            {
                return;
            }
            Initialized = true;
            Dependency.Register<Core.Services.IDialogService, DialogService>();
            Dependency.Register<ILoginService, LoginService>();
            Dependency.Register<IUserService, UserService>();
            Dependency.Register<IOrderService, OrdersService>();
            Dependency.Register<IOrderPageService, OrderPageService>();
            Dependency.Register<IPlatformService, PlatformService>();
            Dependency.Register<IRoomService, RoomService>();
            Dependency.Register<IRoomPageService, DummyRoomPageService>();
           // Dependency.Register<IDopUslugaService, DopUslugaService>();
            Dependency.Register<IDiscountService, DiscountService>();

            //конфигурация навигации
            Dependency.Register<IRoutingService, CustomRoutingService>(singleton: true);
        }

        /// <summary>
        /// Launches activity to start the application
        /// </summary>
        internal static async Task LaunchFirstActivity()
        {
            if (await AuthHelper.CheckHasValidUserAsync())
            {
                CustomRoutingService.LaunchActivity(typeof(RootPageViewModel), noHistory: false);
            }
            else
            {
                CustomRoutingService.LaunchActivity(typeof(LoginPageViewModel), noHistory: true);
            }
        }

        #endregion Methods/Events

        #region Classes/Interfaces

        private class CustomRoutingService : RoutingService
        {
            #region Methods/Events

            public static void LaunchActivity(Type viewModelType, object param = null, bool noHistory = false)
            {
                if (param != null)
                {
                    Type parameterType = param.GetType();
                    Dependency.Register(parameterType, param);
                }

                Activity currentActivity = Dependency.Resolve<Activity>();
                Intent launchIntent = new Intent(currentActivity, typeof(StandardPageActivity));

                launchIntent.PutExtra(StandardPageActivity.LayoutResourceIDKey, PagesLayoutDictionary[viewModelType]);
                launchIntent.PutExtra(StandardPageActivity.EncodedViewModelTypeKey, StandardPageActivity.EncodeViewModelType(viewModelType));
                if (noHistory)
                {
                    launchIntent.AddFlags(ActivityFlags.NoHistory);
                }
                currentActivity.StartActivity(launchIntent);
            }

            public override void Navigate(string relativeUrl, object navigationArgument = null)
            {
                Type type = NavigationDictionary.ResolveType(relativeUrl);
                RegisterPath(relativeUrl, (obj) => LaunchActivity(type, navigationArgument));
                base.Navigate(relativeUrl, navigationArgument);
            }

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces
    }
}
