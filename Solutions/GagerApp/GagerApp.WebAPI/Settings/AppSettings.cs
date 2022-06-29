using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GagerApp.WebAPI.Settings
{
    public class AppSettings
    {
        public string Secret
        {
            get; set;
        }

        public string DatabaseName
        {
            get; set;
        }

        public string ConnectionStringId
        {
            get; set;
        }

        public TimeSpan TokenLifetime
        {
            get;
            set;
        }

        public TimeSpan RefreshTokenLifetime
        {
            get;
            set;
        }
    }
}
