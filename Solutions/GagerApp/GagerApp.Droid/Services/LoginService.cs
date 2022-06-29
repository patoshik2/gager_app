using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GagerApp.Core.Services;
using GagerApp.Model;
using GagerApp.Model.Entities;
using Newtonsoft.Json;


namespace GagerApp.Droid.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            return await AuthHelper.LoginAsync(username, password);
        }
    }
}
