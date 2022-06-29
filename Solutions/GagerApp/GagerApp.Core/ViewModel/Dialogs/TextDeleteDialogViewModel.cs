using System;
using System.Collections.Generic;
using System.Text;
using GagerApp.Core.Services;

namespace GagerApp.Core.ViewModel.Dialogs
{
    public abstract class TextDeleteDialogViewModel : DialogViewModel
    {
        #region Fields
    
        private readonly string _text;

        #endregion Fields

        #region Constructors/Finalizers

        protected TextDeleteDialogViewModel(string text, DialogController dialogController):base(dialogController)
        {
            _text = text;
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public sealed override string Caption => _text;

        public sealed override string NegativeButtonCaption => "Нет";

        public sealed override string NeutralButtonCaption => string.Empty;

        public sealed override string PositiveButtonCaption => "Да";

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// Return string.Empty on successful validation, or the error string otherwise
        /// </summary>
        ///
        protected sealed override bool CanAccept()
        {
            return true;
        }
        protected sealed override bool CanCancel()
        {
            return true;
        }
        protected sealed override bool OnCancel()
        {
          
            return true;
        }

        protected sealed override bool OnThirdButtonAction()
        {
            return false;
        }

        #endregion Methods/Events
    }
}
