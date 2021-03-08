using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherCollector.DAL.Context;

namespace WeatherCollector.Infrastructure
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) =>
            Configuration["Database"] switch
            {
                "Sqlite" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlite(Configuration.GetConnectionString("Sqlite"), 
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.Sqlite")))
                   .AddEntityFrameworkProxies(),

                "SQLServer" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer")))
                   .AddEntityFrameworkProxies(),

                "SqlServer" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"), 
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer")))
                   .AddEntityFrameworkProxies(),

                "" => throw new InvalidOperationException("Тип БД не определён"),
                null => throw new InvalidOperationException("Тип БД не определён"),
                _ => throw new NotSupportedException($"Подключение {Configuration["Database"]} не поддерживается")
            };
    }
}
