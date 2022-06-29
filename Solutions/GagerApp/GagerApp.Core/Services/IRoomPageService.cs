using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    /// <summary>
    /// Service для получения информации для одной комнаты
    /// </summary>
    public interface IRoomPageService
    {
        Task<RoomPageModel> GetRoomAsync(int number);
    }
}
