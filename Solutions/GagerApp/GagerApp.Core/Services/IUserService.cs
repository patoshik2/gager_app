using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.Entities;

namespace GagerApp.Core.Services
{
    public interface IUserService
    {
        Task<string> GetUserFIOAsync();
        void Logout();
       
    }
}
