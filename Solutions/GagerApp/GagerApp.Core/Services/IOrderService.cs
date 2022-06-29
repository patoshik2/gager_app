using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IOrderService
    {
        Task <IEnumerable<OrderDTO>> GetOrdersAsync();
      
    }
}
