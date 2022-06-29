using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GagerApp.Core.Services;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Droid.Services
{
    public class DummyOrderService : IOrderService
    {
        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
        {
            return await Task.Delay(2000).ContinueWith((completedTask) => CreateDummyOrdersList());
        }

        private static List<OrderDTO> CreateDummyOrdersList()
        {
            List<OrderDTO> orderModels = new List<OrderDTO>();
            OrderDTO orderModel = new OrderDTO()
            {
                StartTime = new DateTime(2020, 7, 15, 9, 0, 0),
                FinishTime = new DateTime(2020, 7, 15, 11, 0, 0),
                Number = 1,
                Address = "г.Барнаул, пр. Северо Власихинский 102",
                Status = OrderStatus.Confirmed
            };

            OrderDTO orderModel1 = new OrderDTO()
            {
                StartTime = new DateTime(2020, 7, 15, 11, 0, 0),
                FinishTime = new DateTime(2020, 7, 15, 13, 0, 0),
                Number = 2,
                Address = "г.Барнаул, пр. Северо Власихинский 111",
                Status = OrderStatus.Confirmed
            };

            OrderDTO orderModel2 = new OrderDTO()
            {
                StartTime = new DateTime(2020, 7, 15, 13, 0, 0),
                FinishTime = new DateTime(2020, 7, 15, 15, 0, 0),
                Number = 3,
                Address = "г.Барнаул, пр. Северо Власихинский 85",
                Status = OrderStatus.Rejected
            };

            OrderDTO orderModel3 = new OrderDTO()
            {
                StartTime = new DateTime(2020, 7, 15, 15, 0, 0),
                FinishTime = new DateTime(2020, 7, 15, 17, 0, 0),
                Number = 4,
                Address = "г.Барнаул, пр. Северо Власихинский 96",
                Status = OrderStatus.Pending
            };

            orderModels.Add(orderModel);
            orderModels.Add(orderModel1);
            orderModels.Add(orderModel2);
            orderModels.Add(orderModel3);
            return orderModels;
        }
    }
}
