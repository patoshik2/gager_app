using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class CreateRoomRequest
    {
        #region Constructors/Finalizers

        public CreateRoomRequest(int orderID, string roomName)
        {
            OrderID = orderID;
            RoomName = roomName ?? throw new ArgumentNullException(nameof(roomName));
        }

        private CreateRoomRequest()
        {
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public int OrderID
        {
            get;
            set;
        }

        public string RoomName
        {
            get;
            set;
        }

        #endregion Properties/Indexers
    }
}
