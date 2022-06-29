using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GagerApp.WebAPI.Helpers
{
    public static class HttpContextExtensions
    {
        public static int? GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return null;
            }

            var value = httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return string.IsNullOrEmpty(value) ? default(int?) : int.Parse(value);
        }

    }
}
