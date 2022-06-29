using System;
using System.Collections.Generic;
using System.Text;
using Calcium.Messaging;
using GagerApp.Model.DTO;

namespace GagerApp.Core.ViewModel.Messages
{
    public class RoomDeletedMessage : MessageBase<RoomDTO>
    {
        public RoomDeletedMessage(object sender, RoomDTO payload) : base(sender, payload)
        {
        }
    }
}
