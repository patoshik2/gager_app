using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Helpers;

using GagerApp.WebAPI.Services;
using GagerApp.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GagerApp.WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(nameof(AppSettings));
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            //Authentication context
            services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(appSettings.ConnectionStringId));
                }
                );

            //Scoped services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
