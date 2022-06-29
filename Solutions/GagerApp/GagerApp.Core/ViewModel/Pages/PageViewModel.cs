using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Calcium;
using Calcium.Services;
using Calcium.UIModel;
using GagerApp.Model.DTO;
using TomsToolbox.ObservableCollections;

namespace GagerApp.Core.ViewModel.Pages
{
    /// <summary>
    /// A base view model for pages that don't require parameter in constructor
    /// </summary>
    public abstract class PageViewModel : ViewModelBase
    {
        #region Constructors/Finalizers

        protected PageViewModel()
        {
        }

        #endregion Constructors/Finalizers

        #region Methods/Events

        public static INavigationToken GetNavigationTokenFor<TPageViewModel>() where TPageViewModel : PageViewModel
        {
            return new NavigationAssistant<TPageViewModel>();
        }

        #endregion Methods/Events

        #region Classes/Interfaces

        public interface INavigationToken
        {
            #region Methods/Events

            void NavigateToDestination();

            #endregion Methods/Events
        }

        private class NavigationAssistant<TPageViewModel> : INavigationToken where TPageViewModel : PageViewModel
        {
            #region Methods/Events

            public void NavigateToDestination()
            {
                var type = typeof(TPageViewModel);
                var navigationKey = NavigationDictionary.Register(type);
                Dependency.Resolve<INavigationService>().Navigate(navigationKey);
            }

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces

    }

    /// <summary>
    /// A base view model for pages that require parameter in constructor
    /// </summary>
    /// <typeparam name="T">parameter (model) to be used in constructor along with other services</typeparam>
    public abstract class PageViewModel<T> : ViewModelBase
    {
        #region Constructors/Finalizers

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        protected PageViewModel(T param)
        {
        }

        #endregion Constructors/Finalizers

        #region Methods/Events

        /// <summary>
        /// Нужно вызывать для того, чтобы начать навигацию в PageViewModel
        /// </summary>
        /// <typeparam name="TPageViewModel"></typeparam>
        /// <returns></returns>
        public static INavigationToken GetNavigationTokenFor<TPageViewModel>() where TPageViewModel : PageViewModel<T>
        {
            return new NavigationAssistant<TPageViewModel>();
        }

        #endregion Methods/Events

        #region Classes/Interfaces

        public interface INavigationToken
        {
            #region Methods/Events
            /// <summary>
            /// Для навигации нужно вызвать этот метод
            /// </summary>
            /// <param name="parameter"></param>
            void NavigateToDestinationWith(T parameter);
            #endregion Methods/Events
        }

        private class NavigationAssistant<TPageViewModel> : INavigationToken where TPageViewModel : PageViewModel<T>
        {
            #region Methods/Events

            public void NavigateToDestinationWith(T parameter)
            {
                var type = typeof(TPageViewModel);
                var navigationKey = NavigationDictionary.Register(type);
                Dependency.Resolve<INavigationService>().Navigate(navigationKey, parameter);
            }

            #endregion Methods/Events
        }

        #endregion Classes/Interfaces
    }
}
