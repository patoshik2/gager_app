using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors
        {
            get; set;
        }
    }
}
