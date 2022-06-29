using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Services;

namespace GagerApp.Core.ViewModel.Dialogs
{
    /// <summary>
    /// A base class for all dialog view models
    /// </summary>
    public abstract class DialogViewModel : ViewModelBase
    {
        #region Fields

        private readonly ActionCommand<object> _negativeCommand;
        private readonly ActionCommand<object> _neutralCommand;
        private readonly ActionCommand<object> _positiveCommand;
        private readonly DialogController _dialogController;

        #endregion Fields

        #region Constructors/Finalizers

        public DialogViewModel(DialogController dialogController)
        {
            _positiveCommand = new ActionCommand(OnAccept, (arg) => CanAccept());
            _negativeCommand = new ActionCommand(OnCancel, (arg) => CanCancel());
            _neutralCommand = new ActionCommand(OnThirdButtonAction, (arg) => CanExecuteThirdButtonAction());

            _dialogController = dialogController ?? throw new ArgumentNullException(nameof(dialogController));
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        /// <summary>
        /// For binding purposes
        /// </summary>
        public bool Cancelable => CanCancel();

        public virtual string Caption
        {
            get;
            set;
        }

        public abstract string NegativeButtonCaption
        {
            get;
        }

        public ICommand NegativeCommand => _negativeCommand;

        public abstract string NeutralButtonCaption
        {
            get;
        }

        public ICommand NeutralCommand => _neutralCommand;

        public abstract string PositiveButtonCaption
        {
            get;
        }

        public ICommand PositiveCommand => _positiveCommand;

        #endregion Properties/Indexers

        #region Methods/Events

        protected static void ShowDialog<TDialogViewModel>(object param = null) where TDialogViewModel : DialogViewModel
        {
            var type = typeof(TDialogViewModel);
            var navigationKey = NavigationDictionary.Register(type);
            Dependency.Resolve<IDialogService>().ShowDialog(navigationKey, param);
        }

        protected abstract bool CanAccept();

        protected void CanAcceptChanged()
        {
            _positiveCommand.RaiseCanExecuteChanged();
        }

        protected abstract bool CanCancel();

        protected void CanCancelChanged()
        {
            _negativeCommand.RaiseCanExecuteChanged();
        }

        protected abstract bool CanExecuteThirdButtonAction();

        protected void CanExecuteThirdButtonChanged()
        {
            _neutralCommand.RaiseCanExecuteChanged();
        }

        protected void CloseWithState(DialogController.CloseState state)
        {
            _dialogController.Close(this, state);
        }

        /// <summary>
        /// Return true - the dilaog will close.
        /// Return false - the dialog won't close.
        /// </summary>
        /// <returns></returns>
        protected abstract Task<bool> OnAcceptAsync();

        /// <summary>
        /// Return true - the dialog will cancel;
        /// Return false - the dialog won't cancel.
        /// </summary>
        /// <returns></returns>
        protected abstract bool OnCancel();

        /// <summary>
        /// Return true - the dialog will close;
        /// Return false - the dialog won't close.
        /// </summary>
        /// <returns></returns>
        protected abstract bool OnThirdButtonAction();

        private async void OnAccept(object arg)
        {
            if (await OnAcceptAsync())
            {
                CloseWithState(DialogController.CloseState.Positive);
            }
        }

        private void OnCancel(object arg)
        {
            if (OnCancel())
            {
                CloseWithState(DialogController.CloseState.Negative);
            }
        }

        private void OnThirdButtonAction(object obj)
        {
            if (OnThirdButtonAction())
            {
                CloseWithState(DialogController.CloseState.Neutral);
            }
        }

        #endregion Methods/Events
    }
}
