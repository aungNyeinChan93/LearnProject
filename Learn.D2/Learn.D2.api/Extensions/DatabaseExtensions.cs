using Learn.D2.api.Models.Settings;
using Learn.D2.Database;
using Learn.D2.GameStoreDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.SqlTypes;
using System.Diagnostics.SymbolStore;
using System.Net.NetworkInformation;

namespace Learn.D2.api.Extensions
{
    public static class DatabaseExtensions
    {

        public static WebApplicationBuilder MapDatabase(this WebApplicationBuilder builder)
        {
           
            var serviceProvider = builder.Services.BuildServiceProvider();
            var dbOptions = serviceProvider.GetRequiredService<IOptions<DbConnectionSettings>>();

            builder
                .AddDefaultDatabase(dbOptions)
                .AddGameStoreDb(dbOptions);

            return builder;
        }

        public static WebApplicationBuilder AddDefaultDatabase(
            this WebApplicationBuilder builder,IOptions<DbConnectionSettings> opt)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(opt.Value.Default);
            });


            return builder;
        }

        public static WebApplicationBuilder AddGameStoreDb(
            this WebApplicationBuilder builder,IOptions<DbConnectionSettings> opt)
        {
            builder.Services.AddDbContext<GameStoreDbContext>(options =>
            {
                options.UseSqlServer(opt.Value.GameStore);
            });

            return builder;
        }

    }
}
