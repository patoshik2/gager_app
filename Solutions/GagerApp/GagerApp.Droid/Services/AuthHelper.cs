using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
using GagerApp.Model.Entities;
using Newtonsoft.Json;

namespace GagerApp.Droid.Services
{
    internal static class AuthHelper
    {
        #region Fields

        private const string RefreshTokenKey = "TokenRefresh";
        private const string TokenInfoGroupKey = "TokenInfo";
        private const string TokenKey = "Token";

        #endregion Fields

        #region Methods/Events

        public static async Task<bool> CheckHasValidUserAsync()
        {
            string url = EndPoints.RootUrl + EndPoints.Users.Get;
            var uri = new System.Uri(url);
            var responce = await GetAsyncWithAuth(uri);
            switch (responce.StatusCode)
            {
                case HttpStatusCode.OK:
                    return true;
                default:
                    return false;
            }
        }

        public static async Task<HttpResponseMessage> DeleteAsyncWithAuth(Uri uri)
        {
            var httpClient = GetAuthHttpClient();
            var responce = await httpClient.DeleteAsync(uri);

            if (responce.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Trying to refresh token
                if (await RefreshTokenAsync())
                {
                    //Retry get one more time
                    httpClient = GetAuthHttpClient();
                    responce = await httpClient.DeleteAsync(uri);
                }
            }

            return responce;
        }

        public static async Task<HttpResponseMessage> GetAsyncWithAuth(Uri uri)
        {
            var httpClient = GetAuthHttpClient();
            var responce = await httpClient.GetAsync(uri);

            if (responce.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Trying to refresh token
                if (await RefreshTokenAsync())
                {
                    //Retry get one more time
                    httpClient = GetAuthHttpClient();
                    responce = await httpClient.GetAsync(uri);
                }
            }

            return responce;
        }

        public static async Task<LoginResult> LoginAsync(string username, string password)
        {
            if (!IsNetworkAvailable())
            {
                return LoginResult.NetworkError;
            }

            var request = new AuthenticateRequest()
            {
                Username = username,
                Password = password
            };

            HttpClient client = new HttpClient();

            string url = EndPoints.RootUrl + EndPoints.Users.Login;
            var uri = new System.Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    AuthSuccessResponse responceUser;
                    try
                    {
                        responceUser = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthSuccessResponse>(jsonString);
                    }
                    catch (Exception)
                    {
                        //TODO: create special error for this case
                        return LoginResult.UnknownError;
                    }
                    if (responceUser == null)
                    {
                        //This shouldn't happen
                        return LoginResult.NetworkError;
                    }

                    SaveUser(responceUser);
                    return LoginResult.Success;
                case System.Net.HttpStatusCode.BadRequest:
                    return LoginResult.InvalidCredentials;

                //TODO: check other possible responces

                default:
                    return LoginResult.NetworkError;
            }
        }

        public static async Task<HttpResponseMessage> PostAsyncWithAuth(Uri uri, HttpContent content)
        {
            var httpClient = GetAuthHttpClient();
            var responce = await httpClient.PostAsync(uri, content);

            if (responce.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Trying to refresh token
                if (await RefreshTokenAsync())
                {
                    //Retry post one more time
                    httpClient = GetAuthHttpClient();
                    responce = await httpClient.PostAsync(uri, content);
                }
            }

            return responce;
        }

        public static async Task<HttpResponseMessage> PutAsyncWithAuth(Uri uri, HttpContent content)
        {
            var httpClient = GetAuthHttpClient();
            var responce = await httpClient.PutAsync(uri, content);

            if (responce.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                //Trying to refresh token
                if (await RefreshTokenAsync())
                {
                    //Retry get one more time
                    httpClient = GetAuthHttpClient();
                    responce = await httpClient.PutAsync(uri, content);
                }
            }
            return responce;
        }

        public static void SaveUser(AuthSuccessResponse authenticateResponse)
        {
            ISharedPreferences sp = Application.Context.GetSharedPreferences(TokenInfoGroupKey, FileCreationMode.Private);
            ISharedPreferencesEditor edit = sp.Edit();
            edit.PutString(TokenKey, authenticateResponse.Token);
            edit.PutString(RefreshTokenKey, authenticateResponse.RefreshToken);
            edit.Apply();
        }

        private static HttpClient GetAuthHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetToken());
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static string GetRefreshToken()
        {
            ISharedPreferences sp = Application.Context.GetSharedPreferences(TokenInfoGroupKey, FileCreationMode.Private);
            return sp.GetString(RefreshTokenKey, string.Empty);
        }

        private static string GetToken()
        {
            ISharedPreferences sp = Application.Context.GetSharedPreferences(TokenInfoGroupKey, FileCreationMode.Private);
            return sp.GetString(TokenKey, string.Empty);
        }

        public static bool IsNetworkAvailable()
        {
            bool networkAvailable = false;
            Android.Net.ConnectivityManager connectivityManager = (Android.Net.ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                var capability = connectivityManager.GetNetworkCapabilities(connectivityManager.ActiveNetwork);
                networkAvailable = capability != null && capability.HasCapability(Android.Net.NetCapability.Internet);
            }
            else
            {
                var networks = connectivityManager.GetAllNetworks();
                foreach (var network in networks)
                {
                    var capability = connectivityManager.GetNetworkCapabilities(network);
                    networkAvailable |= (capability != null && capability.HasCapability(Android.Net.NetCapability.Internet));
                }
            }
            return networkAvailable;
        }

        private static async Task<bool> RefreshTokenAsync()
        {
            var request = new RefreshTokenRequest()
            {
                Token = GetToken(),
                RefreshToken = GetRefreshToken()
            };

            HttpClient client = new HttpClient();

            string url = EndPoints.RootUrl + EndPoints.Users.Refresh;
            var uri = new System.Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await client.PostAsync(uri, content);

            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await responce.Content.ReadAsStringAsync();
                AuthSuccessResponse responceUser;
                try
                {
                    responceUser = JsonConvert.DeserializeObject<AuthSuccessResponse>(jsonString);
                }
                catch (Exception)
                {
                    //TODO: try to handle error
                    return false;
                }
                if (responceUser == null)
                {
                    //This shouldn't happen
                    return false;
                }

                SaveUser(responceUser);
                return true;
            }
            return false;
        }

        #endregion Methods/Events
    }
}
