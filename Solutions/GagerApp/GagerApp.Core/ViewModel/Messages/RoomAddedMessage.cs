using System;
using System.Collections.Generic;
using System.Text;
using Calcium.Messaging;
using GagerApp.Model.DTO;

namespace GagerApp.Core.ViewModel.Messages
{
    public class RoomAddedMessage : MessageBase<RoomDTO>
    {
        public RoomAddedMessage(object sender, int orderNumber, RoomDTO payload) : base(sender, payload)
        {
            OrderNumber = orderNumber;
        }

        public int OrderNumber
        {
            get;
        }
    }
}
