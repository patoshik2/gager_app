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
using GagerApp.Model.Entities;

namespace GagerApp.Droid.Services
{
    public class DummyRoomPageService : IRoomPageService
    {

        public async Task<RoomPageModel> GetRoomAsync(int number)
        {
            RoomPageModel roomPageModel = new RoomPageModel()
            {
                SumCount = 750000,
                Number = number
            };
            return await Task.Delay(2500).ContinueWith((completedTask) => roomPageModel);
        }

    }
}
