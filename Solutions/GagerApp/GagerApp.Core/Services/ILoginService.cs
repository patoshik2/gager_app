using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GagerApp.Core.Services
{
    public interface ILoginService
    {

        Task<LoginResult> LoginAsync(string username, string password);

    }
}
