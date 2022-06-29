using System;
using System.Collections.Generic;
using System.Text;
using Calcium.Messaging;
using GagerApp.Model.Entities;

namespace GagerApp.Core.ViewModel.Messages
{
    public class OrderStatusUpdatedMessage : MessageBase<OrderStatus>
    {
        public OrderStatusUpdatedMessage(object sender, int orderNumber, OrderStatus payload)
            : base(sender, payload)
        {
            OrderNumber = orderNumber;
        }

        public int OrderNumber
        {
            get;
        }

        /// <summary>
        /// Alias for <see cref="MessageBase{TPayload}.Payload"/> property
        /// </summary>
        public OrderStatus OrderStatus => Payload;
    }
}
