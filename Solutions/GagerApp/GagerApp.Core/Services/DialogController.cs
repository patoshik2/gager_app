using System;
using System.Collections.Generic;
using System.Text;
using Calcium;
using Calcium.Concurrency;
using Calcium.Services;

namespace GagerApp.Core.Services
{
	/// <summary>
	/// This class is used primarily to close a dialog
	/// </summary>
    public class DialogController
    {
        /// <summary>
        /// Call this method to dismiss the dialog.
        /// The <see cref="IDialogService" />
        /// implementation dismisses the dialog immediately.
        /// </summary>
        /// <param name="e">An event args object,
        /// which may be used to convey information to the 
        /// <see cref="IDialogService" /> implementation</param>
        public virtual void Close(object dialog, CloseState state)
        {
            var messenger = Dependency.Resolve<IMessenger>();
            messenger.PublishAsync(new DialogCloseRequestMessage(dialog));
        }

        public class DialogCloseRequestMessage
        {
            public DialogCloseRequestMessage(object viewModel)
            {
                ViewModelRequested = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            }

            public object ViewModelRequested
            {
                get;
            }
        }

        public enum CloseState
        {
            Positive,
            Negative,
            Neutral
        }
    }
}
