using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Core.Services
{
    public interface IDialogService
    {
        void ShowDialog(string dialogKey, object param = null);
    }
}
