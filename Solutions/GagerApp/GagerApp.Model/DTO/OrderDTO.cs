using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Calcium.ComponentModel;
using GagerApp.Model.Entities;

namespace GagerApp.Model.DTO
{
    public class OrderDTO : ObservableBase
    {
        private OrderStatus _status;

        public DateTime StartTime
        {
            get; set;
        }

        public DateTime FinishTime
        {
            get; set;
        }

        public int Number
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }

        public OrderStatus Status
        {
            get => _status; set => Set(ref _status,  value);
        }
    }
}
