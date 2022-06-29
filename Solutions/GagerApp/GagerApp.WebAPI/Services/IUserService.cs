using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagerApp.Model.Entities;
using GagerApp.WebAPI.Models;

namespace GagerApp.WebAPI.Services
{
    public interface IUserService
    {
        Task<AuthenticationResult> LoginAsync(AuthenticateRequest model);

        Task<UserProfile> GetByIdAsync(int id);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
