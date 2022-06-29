using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model
{
    public static class EndPoints
    {
        public static readonly string RootUrl = "http://vyk.somee.com/";

        private const string Root = "api";

        private const string Version = "v1";

        private const string Base = Root + "/" + Version;

        public static class Users
        {
            /// <summary>
            /// Авторизовать пользователя
            /// </summary>
            public const string Login = Base + "/" + nameof(Users) + "/" + nameof(Login);
            /// <summary>
            /// Получить список пользователей
            /// </summary>
            public const string Get = Base + "/" + nameof(Users) + "/" + nameof(Get);
            /// <summary>
            /// Обновить refresh-токен
            /// </summary>
            public const string Refresh = Base + "/" + nameof(Users) + "/" + nameof(Refresh);
        }

        public static class GagerOrders
        {
            /// <summary>
            /// Получить все заявки. Query can contain date
            /// </summary>
            public const string Get = Base + "/" + nameof(GagerOrders) + "/" + nameof(Get);

            /// <summary>
            /// Get all Gager orders for date <paramref name="dateTime"/>
            /// </summary>
            /// <param name="dateTime"></param>
            /// <returns></returns>
            public static string GetByDate(DateTime dateTime)
            {
                return Get + $"?date={dateTime.ToString("dd-MM-yyyy")}";
            }

            /// <summary>
            /// Получить полную информацию по заявке {orderNumber}
            /// </summary>
            public const string GetFull = Base + "/" + nameof(GagerOrders) + "/" + nameof(GetFull) + "/" + "{orderNumber}";

            public static string GetFullByNumber(int orderNumber)
            {
                return GetFull.Replace("{orderNumber}", orderNumber.ToString());
            }

            /// <summary>
            /// Поменять статус замера {orderNumber}. Body should contain <see cref="Entities.UpdateOrderStatusRequest"/>
            /// </summary>
            public const string UpdateStatus = Base + "/" + nameof(GagerOrders) + "/" + nameof(UpdateStatus);

            /// <summary>
            /// удалить заявку {orderNumber}
            /// </summary>
            public const string Delete = Base + "/" + nameof(GagerOrders) + "/" + nameof(Delete) + "/" + "{orderNumber}";

            public static string DeleteByOrderId(int orderNumber)
            {
                return Delete.Replace("{orderNumber}", orderNumber.ToString());
            }
        }

        public static class Clients
        {
            /// <summary>
            /// Primary entry point for retreiving clients.
            /// By default returns all clients.
            /// </summary>
            public const string Get = Base + "/" + nameof(Clients) + "/" + nameof(Get);

            public static string GetByOrderNumber(int orderNumber)
            {
                return Get + $"?orderId={orderNumber}";
            }
        }

        public static class Rooms
        {
            ///<summary>
            /// Primary entry for retreiving rooms.
            /// Query can contain orderId
            /// </summary>
            public const string Get = Base + "/" + nameof(Rooms) + "/" + nameof(Get);

            public static string GetByOrderNumber(int orderNumber)
            {
                return Get + $"?orderId={orderNumber}";
            }

            /// <summary>
            /// Получить стоимость всего в комнате с номером {roomNumber}
            /// </summary>
            public const string GetCost = Base + "/" + nameof(Rooms) + "/" + nameof(GetCost) + "/" + "{roomNumber}";

            public static string GetCostById(int roomNumber)
            {
                return GetCost.Replace("{roomNumber}", roomNumber.ToString());
            }

            /// <summary>
            /// Получить полную информацию о комнате с номером {roomNumber}
            /// </summary>
            public const string GetFull = Base + "/" + nameof(Rooms) + "/" + nameof(GetFull) + "/" + "{roomNumber}";

            public static string GetFullById(int roomNumber)
            {
                return GetFull.Replace("{roomNumber}", roomNumber.ToString());
            }

            /// <summary>
            /// Create new room.
            /// Body must contain CreateRoomRequest
            /// </summary>
            public const string Create = Base + "/" + nameof(Rooms) + "/" + nameof(Create);

            /// <summary>
            /// Удалить комнату с номером {roomNumber}
            /// </summary>
            public const string Delete = Base + "/" + nameof(Rooms) + "/" + nameof(Delete) + "/" + "{roomNumber}";

            public static string DeleteById(int roomNumber)
            {
                return Delete.Replace("{roomNumber}", roomNumber.ToString());
            }
        }
    }

}
