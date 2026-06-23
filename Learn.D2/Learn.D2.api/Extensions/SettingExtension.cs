using Learn.D2.api.Models.Settings;
using Microsoft.Extensions.Options;

namespace Learn.D2.api.Extensions
{
    public static class SettingExtension
    {
        public static WebApplicationBuilder MapSettings(this WebApplicationBuilder builder)
        {
            builder.Configuration
                .AddJsonFile("Configuration/firebasesettings.json",optional:true,reloadOnChange:true)
                .AddJsonFile("Configuration/emailsettings.json",optional:true,reloadOnChange:true)
                .AddJsonFile("Configuration/dbconnectionsettings.json",optional:true,reloadOnChange:true)
                .AddJsonFile("Configuration/appsettings.json", optional:true,reloadOnChange:true);

            builder.Services.AddOptions();

            builder.AddFirebaseSetting()
                .AddEmailSettings()
                .AddDatabaseSettings();

            return builder;
        }

        public static WebApplicationBuilder AddFirebaseSetting(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<FirebaseSettings>(
                builder.Configuration.GetSection("FirebaseSettings"));

            return builder;
        }

        public static WebApplicationBuilder AddEmailSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            return builder; 
        }

        public static WebApplicationBuilder AddDatabaseSettings(this WebApplicationBuilder builder )
        {
            builder.Services.Configure<DbConnectionSettings>(
                builder.Configuration.GetSection("DbConnectionSettings"));
            return builder;
        }
    }
}
