using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IOrderPageService
    {
        Task<FullOrderDTO> GetFullOrderAsync(int number);
        Task<bool> UpdateZamerStatusAsync(int number, OrderStatus newStatus);
    }
}
