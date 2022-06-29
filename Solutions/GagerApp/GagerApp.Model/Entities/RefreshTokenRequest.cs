using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class RefreshTokenRequest
    {
        public string Token
        {
            get; set;
        }

        public string RefreshToken
        {
            get; set;
        }
    }
}
