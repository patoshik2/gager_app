using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class RoomPageModel : OrderModel
    {
        public string TotalSum => SumCount.ToString() + " руб.";
        public int SumCount { get; set; }
        public string Number_ => "Заявка №" + Number.ToString();
    }
}
