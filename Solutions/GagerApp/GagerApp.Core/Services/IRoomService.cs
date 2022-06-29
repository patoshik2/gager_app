using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDTO>> GetRoomsAsync(int orderNumber);
        Task<double?> GetRoomCostAsync(int roomNumber);
        Task<RoomDTO> AddNewRoomAsync(int orderNumber, string roomName);
        Task<FullRoomDTO> GetFullRoomAsync(int roomNumber);
        Task<bool> DeleteRoomAsync(int roomNumber);
    }
}
