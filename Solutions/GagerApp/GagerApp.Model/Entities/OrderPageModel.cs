using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GagerApp.Model.Entities
{
    [Obsolete("Use FullOrderDTO", true)]
    public class OrderPageModel : OrderModel
    {
        private bool _isMontagAccepted;
        private bool _isCloseOrderButtonEnabled;
        private bool _isError;
        private bool _isRestore;

        public DateTime ZamerDate
        {
            get; set;
        }

        public string ZamerTime => "с " + ZamerTimeStart.ToShortTimeString() + " до " + ZamerTimeEnd.ToShortTimeString();

        public DateTime ZamerTimeStart
        {
            get; set;
        }

        public DateTime ZamerTimeEnd
        {
            get; set;
        }

        public string FIO
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public string Adress
        {
            get; set;
        }

        public string Notes
        {
            get; set;
        }

        public OrderStatus StatusZamer
        {
            get; set;
        }

        public bool IsMontagAccepted
        {
            get => _isMontagAccepted; set => Set(ref _isMontagAccepted, value);
        }


        public bool IsCloseOrderButtonEnabled
        {
            get => _isCloseOrderButtonEnabled; set => Set(ref _isCloseOrderButtonEnabled, value);
        }

        public bool IsError
        {
            get => _isError; set => Set(ref _isError, value);
        }
        public bool IsRestore
        {
            get => _isRestore; set => Set(ref _isRestore, value);
        }
        public DateTime MontagDate
        {
            get; set;
        }

        public string MontagTime => "с " + MontagTimeStart.ToShortTimeString() + " до " + MontagTimeEnd.ToShortTimeString();

        public DateTime MontagTimeStart
        {
            get; set;
        }

        public DateTime MontagTimeEnd
        {
            get; set;
        }

        public string Number_ => "Заявка №" + Number.ToString();

    }
}
