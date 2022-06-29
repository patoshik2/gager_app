using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Calcium.Services;
using GagerApp.Core.Services;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using Newtonsoft.Json;

namespace GagerApp.Droid.Services
{
    public class OrderPageService: IOrderPageService
    {
        private readonly IMessenger _messenger;

        public OrderPageService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public async Task<FullOrderDTO> GetFullOrderAsync(int number)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return null;
            }

            string url = EndPoints.RootUrl + EndPoints.GagerOrders.GetFullByNumber(number);
            var uri = new System.Uri(url);

            var response = await AuthHelper.GetAsyncWithAuth(uri);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    FullOrderDTO order = null;
                   
                    try
                    {
                        order = JsonConvert.DeserializeObject<FullOrderDTO>(jsonString);
                    }
                    catch (Exception)
                    {
                       return  null;
                    }
                   
                    return order;

                //TODO:Обработать другие варианты!

                default:
                    break;
            }

            //TODO: Возвратить что-то осмысленное 
            return null;
        }

        public async Task<bool> UpdateZamerStatusAsync(int number, OrderStatus newStatus)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return false;
            }

            string url = EndPoints.RootUrl + EndPoints.GagerOrders.UpdateStatus;
            var uri = new System.Uri(url);
            UpdateOrderStatusRequest statusRequest = new UpdateOrderStatusRequest( number, newStatus );
            var json = JsonConvert.SerializeObject(statusRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responce = await AuthHelper.PutAsyncWithAuth(uri, content);

            if (responce.IsSuccessStatusCode)
            {
                _ = _messenger.PublishAsync(new Core.ViewModel.Messages.OrderStatusUpdatedMessage(this, number, newStatus));
            }
            //TODO: Возвратить что-то осмысленное 
            return responce.IsSuccessStatusCode;
        }
    }
}
