using System;

namespace GagerApp.Core.Services
{
    public enum LoginResult
    {
        Success,
        InvalidCredentials,
        NetworkError,
        ServerError,
        UnknownError,
    }

    public static class LoginResultExtensions
    {
        public static string Translate(this LoginResult loginResult)
        {
            switch (loginResult)
            {
                case LoginResult.Success:
                    return string.Empty;
                case LoginResult.InvalidCredentials:
                    return "Неверное имя пользователя или пароль";
                case LoginResult.ServerError:
                    return "Ошибка сервера";
                case LoginResult.NetworkError:
                    return "Ошибка сети";
                case LoginResult.UnknownError:
                default:
                    return "Неопознанная ошибка";
            }
        }
    }

}
