using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IZamerService
    {
        Task<ZamerPageModel> GetZamersAsync(int number);
    }
}
