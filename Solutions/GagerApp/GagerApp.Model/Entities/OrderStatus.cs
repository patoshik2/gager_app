using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public enum OrderStatus
    {
        /// <summary>
        /// Заявка не закрыта
        /// </summary>
        Pending = 1,
        /// <summary>
        /// Заявка закрыта с положительным результатом
        /// </summary>
        Confirmed = 2,
        /// <summary>
        /// Заявка закрыта с отрицательным результатом
        /// </summary>
        Rejected = 3,
    }

    public static class OrderStatusExtensions
    {
        public static string Translate(this OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Pending:
                    return "в очереди";
                case OrderStatus.Rejected:
                    return "отказано";
                case OrderStatus.Confirmed:
                    return "выполнено";
                default:
                    return string.Empty;
            }
        }
    }
}
