using System;
using System.Collections.Generic;
using System.Text;
using GagerApp.Model.Entities;

namespace GagerApp.Model.DTO
{
    public class FullOrderDTO
    {
        public DateTime Date
        {
            get; set;
        }
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

        public OrderStatus Status
        {
            get; set;
        }
   
        public ClientDTO Client
        {
            get; set;
        }
       
        public List<string> TelefonNumber
        {
            get; set;
        }

        public string Notes
        {
            get; set;
        }

        public AdressDTO Adress
        {
            get; set;
        }

        public List<RoomDTO> Rooms
        {
            get; set;
        }

    }
}
