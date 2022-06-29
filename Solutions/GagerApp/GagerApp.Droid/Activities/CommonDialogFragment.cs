using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Calcium;
using Calcium.Messaging;
using Calcium.Services;
using GagerApp.Core.Services;
using GagerApp.Droid.Services;
using Newtonsoft.Json;

namespace GagerApp.Droid.Activities
{
    public class CommonDialogFragment :
        BaseDialogFragment,
        IMessageSubscriber<DialogController.DialogCloseRequestMessage>
    {
        #region Fields

        private static readonly string EncodedParameterKey = nameof(CommonDialogFragment) + "." + nameof(EncodedParameterKey);
        private static readonly string EncodedParameterTypeKey = nameof(CommonDialogFragment) + "." + nameof(EncodedParameterTypeKey);
        private static readonly string EncodedViewModelTypeKey = $"{nameof(CommonDialogFragment)}.{nameof(EncodedViewModelTypeKey)}";
        private static readonly string LayoutResourceIDKey = $"{nameof(CommonDialogFragment)}.{nameof(LayoutResourceIDKey)}";

        #endregion Fields

        #region Properties/Indexers

        protected sealed override int LayoutResourceId
        {
            get
            {
                var layoutResourceID = Arguments.GetInt(LayoutResourceIDKey, int.MinValue);
                if (layoutResourceID == int.MinValue)
                {
                    throw new ArgumentException("No layout resource id was passed in Arguments.");
                }
                return layoutResourceID;
            }
        }

        #endregion Properties/Indexers

        #region Methods/Events

        public override void OnResume()
        {
            base.OnResume();
            Dependency.Resolve<IMessenger>().Subscribe(this);
        }

        public override void OnPause()
        {
            base.OnPause();
            Dependency.Resolve<IMessenger>().Unsubscribe(this);
        }

        /// <summary>
        /// Instantiates new <see cref="CommonDialogFragment"/> (or it's descendant)
        /// and shows it within <paramref name="hostActivity"/> with <<see cref="DialogFragmentStyle.NoFrame"/>
        /// </summary>
        /// <param name="hostActivity"></param>
        /// <param name="layoutID"></param>
        /// <param name="viewModelType"></param>
        /// <param name="param"></param>
        public static TFragment ShowDialog<TFragment>(AndroidX.Fragment.App.FragmentActivity hostActivity, int layoutID, Type viewModelType, object param = null) where TFragment : CommonDialogFragment, new()
        {
            if (viewModelType is null)
            {
                throw new ArgumentNullException(nameof(viewModelType));
            }

            if (hostActivity is null)
            {
                throw new ArgumentNullException(nameof(hostActivity));
            }

            var dialogFragment = NewInstance<TFragment>(layoutID, viewModelType, param);

            dialogFragment.SetStyle(StyleNoFrame, Resource.Style.AppTheme_Dialog);

            dialogFragment.Show(hostActivity.SupportFragmentManager, $"{dialogFragment.GetType().Name}.{viewModelType.GetType().Name}");

            return dialogFragment;
        }

        protected sealed override object CreateViewModel()
        {
            var viewModelType = DecodeType(Arguments.GetString(EncodedViewModelTypeKey));
            var encodedParameterType = Arguments.GetString(EncodedParameterTypeKey);
            var parameterType = string.IsNullOrEmpty(encodedParameterType) ? null : DecodeType(encodedParameterType);
            var parameter = parameterType == null ? null : DecodeParameter(parameterType, Arguments.GetString(EncodedParameterKey));

            if (parameterType != null)
            {
                Calcium.Dependency.Register(parameterType, parameter);
            }

            var viewModel = Calcium.Dependency.ResolveWithType(viewModelType);

            if (parameterType != null)
            {
                Calcium.Dependency.Register(parameterType, null);
            }

            return viewModel;
        }

        private static void ConfigureInstance(CommonDialogFragment fragment, int layoutID, Type viewModelType, object param)
        {
            Bundle bundle = new Bundle();

            bundle.PutInt(LayoutResourceIDKey, layoutID);

            bundle.PutString(EncodedViewModelTypeKey, EncodeType(viewModelType));

            if (param != null)
            {
                bundle.PutString(EncodedParameterTypeKey, EncodeType(param.GetType()));
                bundle.PutString(EncodedParameterKey, EncodeParameter(param));
            }

            fragment.Arguments = bundle;
        }

        private static object DecodeParameter(Type targetType, string encodedParameter)
        {
            return JsonConvert.DeserializeObject(encodedParameter, targetType, new JsonSerializerSettings() { ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor });
        }

        private static Type DecodeType(string encodedType)
        {
            return Type.GetType(encodedType);
        }

        private static string EncodeParameter(object parameter)
        {
            return JsonConvert.SerializeObject(parameter);
        }

        private static string EncodeType(Type viewModelType)
        {
            return viewModelType.AssemblyQualifiedName;
        }

        private static TFragment NewInstance<TFragment>(int layoutID, Type viewModelType, object param) where TFragment : CommonDialogFragment, new()
        {
            if (viewModelType is null)
            {
                throw new ArgumentNullException(nameof(viewModelType));
            }

            TFragment fragment = new TFragment();
            ConfigureInstance(fragment, layoutID, viewModelType, param);
            return fragment;
        }

        Task IMessageSubscriber<DialogController.DialogCloseRequestMessage>.ReceiveMessageAsync(DialogController.DialogCloseRequestMessage message)
        {
            if (message == null)
            {
                return Task.FromResult<object>(null);
            }

            if (message.ViewModelRequested == GetViewModel())
            {
                Dismiss();
            }

            return Task.FromResult<object>(null);
        }

        #endregion Methods/Events
    }
}
