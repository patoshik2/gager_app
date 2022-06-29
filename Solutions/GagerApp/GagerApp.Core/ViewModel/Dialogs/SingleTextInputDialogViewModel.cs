using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Core.Services;

namespace GagerApp.Core.ViewModel.Dialogs
{
    public abstract class SingleTextInputDialogViewModel : DialogViewModel
    {
        #region Fields

        private readonly string _caption;
        private string _errorText;
        private string _inputText;

        #endregion Fields

        #region Constructors/Finalizers

        protected SingleTextInputDialogViewModel(
            string caption,
            string text,
            string inputText,

            DialogController dialogController)
            : base(dialogController)
        {
            _caption = caption;
            Text = text;
            _errorText = string.Empty;

            InputText = inputText;
            //A fail-safe measure if we've been sent an empty string as inputText
            ErrorText = ValidateInput(InputText);
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public sealed override string Caption => _caption;

        public string ErrorText
        {
            get => _errorText;
            private set
            {
                if (Set(ref _errorText, value) == Calcium.ComponentModel.AssignmentResult.Success)
                {
                    CanAcceptChanged();
                }
            }
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                if (Set(ref _inputText, value) == Calcium.ComponentModel.AssignmentResult.Success)
                {
                    InvalidateErrorText();
                }
            }
        }

        public sealed override string NegativeButtonCaption => "Отмена";

        public sealed override string NeutralButtonCaption => string.Empty;

        public sealed override string PositiveButtonCaption => "OK";

        public string Text
        {
            get;
        }

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// Return string.Empty on successful validation, or the error string otherwise
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        protected abstract string ValidateInput(string inputText);

        protected sealed override bool CanAccept()
        {
            return string.IsNullOrEmpty(_errorText);
        }

        protected sealed override bool CanCancel()
        {
            return true;
        }

        protected sealed override bool CanExecuteThirdButtonAction()
        {
            return false;
        }

        protected sealed override Task<bool> OnAcceptAsync()
        {
            var canAccept = CanAccept();

            if (canAccept)
            {
                PositiveCallback(InputText);
            }
            else
            {
                CanAcceptChanged();
            }

            return Task.FromResult(canAccept);
        }

        protected abstract void PositiveCallback(string inputText);

        protected sealed override bool OnCancel()
        {
            NegativeCallback();
            return true;
        }

        protected abstract void NegativeCallback();

        protected sealed override bool OnThirdButtonAction()
        {
            return false;
        }

        protected void InvalidateErrorText()
        {
            ErrorText = ValidateInput(_inputText);
        }

        #endregion Methods/Events
    }
}
