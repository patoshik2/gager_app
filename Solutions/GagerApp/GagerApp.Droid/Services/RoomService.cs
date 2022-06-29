using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class RoomService : IRoomService
    {
        public async Task<RoomDTO> AddNewRoomAsync(int orderNumber, string roomName)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return null;
            }

            string url = EndPoints.RootUrl + EndPoints.Rooms.Create;
            var uri = new System.Uri(url);

            var json = JsonConvert.SerializeObject(new CreateRoomRequest(orderNumber, roomName));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responce = await AuthHelper.PostAsyncWithAuth(uri, content);

            switch (responce.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await responce.Content.ReadAsStringAsync();
                    RoomDTO room = null;
                    try
                    {
                        room = JsonConvert.DeserializeObject<RoomDTO>(jsonString);
                    }
                    catch (Exception)
                    {
                        //TODO: Обработать exception 

                    }
                    return room;

                //TODO:Обработать другие варианты!

                default:
                    break;
            }

            //TODO: Возвратить что-то осмысленное 
            return null;

        }

        public async Task<IEnumerable<RoomDTO>> GetRoomsAsync(int orderNumber)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return null;
            }
            string url = EndPoints.RootUrl + EndPoints.Rooms.GetByOrderNumber(orderNumber);
            var uri = new System.Uri(url);

            var response = await AuthHelper.GetAsyncWithAuth(uri);

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var jsonString = await response.Content.ReadAsStringAsync();
                    List<RoomDTO> rooms = null;
                    try
                    {

                        rooms = JsonConvert.DeserializeObject<List<RoomDTO>>(jsonString);
                    }
                    catch (Exception)
                    {
                        //TODO: Обработать exception 

                    }
                    return rooms;

                //TODO:Обработать другие варианты!

                default:
                    break;
            }

            //TODO: Возвратить что-то осмысленное 
            return null;
        }

        public async Task<double?> GetRoomCostAsync(int roomNumber)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return default;
            }
            var url = EndPoints.RootUrl + EndPoints.Rooms.GetCostById(roomNumber);
            var uri = new System.Uri(url);

                var response = await AuthHelper.GetAsyncWithAuth(uri);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonString = await response.Content.ReadAsStringAsync();
                        double? cost = null;
                        try
                        {
                       
                          cost = JsonConvert.DeserializeObject<double>(jsonString);
                        }
                        catch (Exception)
                        {
                            //TODO: Обработать exception 

                        }
                        return cost;

                    //TODO:Обработать другие варианты!

                    default:
                        break;
                }

            //TODO: Возвратить что-то осмысленное 
            return null;
        }

        public async Task<FullRoomDTO> GetFullRoomAsync(int roomNumber)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return default;
            }

            var url = EndPoints.RootUrl + EndPoints.Rooms.GetFullById(roomNumber);
            var uri = new System.Uri(url);

                var response = await AuthHelper.GetAsyncWithAuth(uri);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var jsonString = await response.Content.ReadAsStringAsync();
                        FullRoomDTO fullRoom = null;
                        try
                        {                       
                          fullRoom = JsonConvert.DeserializeObject<FullRoomDTO>(jsonString);
                        }
                        catch (Exception)
                        {
                            //TODO: Обработать exception 

                        }
                        return fullRoom;

                    //TODO:Обработать другие варианты!

                    default:
                        break;
                }
            

            //TODO: Возвратить что-то осмысленное 
            return null;
        }

         public async Task<bool> DeleteRoomAsync(int roomNumber)
        {
            if (!AuthHelper.IsNetworkAvailable())
            {
                // TODO: обработать отсутсвие сети 
                return default;
            }

            var url = EndPoints.RootUrl + EndPoints.Rooms.DeleteById(roomNumber);
            var uri = new System.Uri(url);
            var responce = await AuthHelper.DeleteAsyncWithAuth(uri);
            
            //TODO: Возвратить что-то осмысленное 
            return responce.IsSuccessStatusCode;
        }
    }
}
