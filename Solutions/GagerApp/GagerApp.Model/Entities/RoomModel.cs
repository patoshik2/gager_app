using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class RoomModel
    {
        public int ID { get; set; }
        public string RoomCaption { get; set; }
        public string RoomSpace => RoomSpaceCount.ToString() + " кв.м";
        public int RoomSpaceCount { get; set; }
        public string RoomCost => RoomCostCount.ToString() + " руб.";
        public int RoomCostCount { get; set; }
    }
}
