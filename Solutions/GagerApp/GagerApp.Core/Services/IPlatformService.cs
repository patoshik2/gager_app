using System;
using System.Collections.Generic;
using System.Text;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IPlatformService
    {
        void CallPhone(string phone);
    }
}
