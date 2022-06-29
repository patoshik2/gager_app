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
using GagerApp.Core.Services;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using Newtonsoft.Json;

namespace GagerApp.Droid.Services
{
    public class OrdersService : IOrderService
    {
        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return null;
            }

            var currentDate = DateTime.Now;
            string url = EndPoints.RootUrl + EndPoints.GagerOrders.GetByDate(currentDate);
            var uri = new System.Uri(url);

            var response = await AuthHelper.GetAsyncWithAuth(uri);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    List<OrderDTO> orders = null;
                    try
                    {
                        orders = JsonConvert.DeserializeObject<List<OrderDTO>>(jsonString);
                    }
                    catch (Exception)
                    {
                        //TODO: Обработать exception 
                      
                    }
                    return orders;

                    //TODO:Обработать другие варианты!

                default:
                    break;
            }

            //TODO: Возвратить что-то осмысленное 
            return null;
        }
    }
}
