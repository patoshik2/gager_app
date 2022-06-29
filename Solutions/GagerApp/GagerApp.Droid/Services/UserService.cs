using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GagerApp.Core.Services;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using Newtonsoft.Json;

namespace GagerApp.Droid.Services
{
    public class UserService : IUserService
    {
        public async Task<string> GetUserFIOAsync()
        {
            
            string url = EndPoints.RootUrl + EndPoints.Users.Get;
            var uri = new System.Uri(url);

            var response = await AuthHelper.GetAsyncWithAuth(uri);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    UserDTO user = null;
                    try
                    {
                        user =  JsonConvert.DeserializeObject<UserDTO>(jsonString);
                    }
                    catch (Exception)
                    {
                        return string.Empty;

                    }

                    return user.Name+" "+ user.SurName + " " + user.Paternum;

               

                default:
                    break;
            }
            return string.Empty;

        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
