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
using GagerApp.Core.Services;

namespace GagerApp.Droid.Services
{
    public class DummyLoginService : ILoginService
    {
        public Task<LoginResult> LoginAsync(string username, string password)
        {
            return Task.Delay(2000)
                .ContinueWith(
                (completedTask) =>
                {
                    if ((username == "admin") && (password == "password"))
                    {
                        return LoginResult.Success;

                    }
                    return LoginResult.InvalidCredentials;
                    }
                //return (username == "admin") && (password == "password") ? LoginResult.Success : LoginResult.InvalidCredentials;                
                );
        }
    }
}
