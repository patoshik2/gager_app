using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagerApp.WebAPI.Models
{
    public class AuthenticationResult
    {
        public string Token
        {
            get; set;
        }

        public string RefreshToken
        {
            get; set;
        }

        public bool Success
        {
            get; set;
        } = false;

        public IEnumerable<string> Errors
        {
            get; set;
        }

    }
}
