using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Model.Entities;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Helpers;
using GagerApp.WebAPI.Models;
using GagerApp.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GagerApp.WebAPI.Services
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly AppSettings _appSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly DataContext _context;

        #endregion Fields

        #region Constructors/Finalizers


        public UserService(AppSettings appSettings, TokenValidationParameters tokenValidationParameters, DataContext context)
        {
            _appSettings = appSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _context = context;
        }

        #endregion Constructors/Finalizers

        #region Methods/Events

        public async Task<AuthenticationResult> LoginAsync(AuthenticateRequest model)
        {
            var user = await _context.UserProfile.AsQueryable().FirstOrDefaultAsync(x => x.Login == model.Username && x.Password == model.Password);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }

            //Cleanup for expired tokens for current user
            await ClearExpiredTokensAsync(user);

            // authentication successful so generate jwt token
            return await GenerateAuthenticationResultForUserAsync(user);
        }

        private async Task ClearExpiredTokensAsync(UserProfile user)
        {
            var toRemove = _context.RefreshTokens.AsQueryable().Where((token) => token.UserId == user.IdUser && token.ExpiryDate < DateTime.Now);
            _context.RefreshTokens.RemoveRange(toRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfile.AsQueryable().FirstOrDefaultAsync(x => x.IdUser == id);
        }

        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(UserProfile user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_appSettings.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.IdUser,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.Add(_appSettings.RefreshTokenLifetime),
                WorkerId = user.IdProfileWorker

            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token,                
            };
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);

            if (validatedToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "Invalid Token" } };
            }

            var expiryDateUnix =
                long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc > DateTime.UtcNow)
            {
                return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet" } };
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _context.RefreshTokens.SingleOrDefaultAsync(x => x.Token == refreshToken);

            if (storedRefreshToken == null)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not exist" } };
            }

            if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token has expired" } };
            }

            if (storedRefreshToken.JwtId != jti)
            {
                return new AuthenticationResult { Errors = new[] { "This refresh token does not match this JWT" } };
            }

            //Check successful, it's okay to remove token
            _context.RefreshTokens.Remove(storedRefreshToken);
            await _context.SaveChangesAsync();

            var value = validatedToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var userId = string.IsNullOrEmpty(value) ? default : int.Parse(value);

            var user = await _context.UserProfile.FirstOrDefaultAsync((profile) => profile.IdUser == userId );
            return await GenerateAuthenticationResultForUserAsync(user);
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion Methods/Events
    }
}
