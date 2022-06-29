using System;
using System.Collections.Generic;
using System.Text;
using Calcium.ComponentModel;

namespace GagerApp.Model.Entities
{
    [Obsolete("Use OrderDTO", false)]
    public class OrderModel : ObservableBase
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public OrderStatus Status  { get; set; }
    }
}
