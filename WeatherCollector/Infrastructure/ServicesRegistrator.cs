using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherCollector.DAL;
using WeatherCollector.DAL.Context;
using WeatherCollector.Interfaces.Base;

namespace WeatherCollector.Infrastructure
{
    internal static class ServicesRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) =>
            Configuration["Database"] switch
            {
                "Sqlite" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlite(Configuration.GetConnectionString("Sqlite"), 
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.Sqlite"))
                           .UseLazyLoadingProxies()),

                "SQLServer" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer"))
                           .UseLazyLoadingProxies()),

                "SqlServer" => services.AddDbContext<WeatherDB>(
                        opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"), 
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer"))
                           .UseLazyLoadingProxies()),

                "" => throw new InvalidOperationException("Тип БД не определён"),
                null => throw new InvalidOperationException("Тип БД не определён"),
                _ => throw new NotSupportedException($"Подключение {Configuration["Database"]} не поддерживается")
            };

        public static IServiceCollection AddDatabaseFactory(this IServiceCollection services, IConfiguration Configuration) =>
            Configuration["Database"] switch
            {
                "Sqlite" => services.AddDbContextFactory<WeatherDB>(
                    opt => opt.UseSqlite(Configuration.GetConnectionString("Sqlite"),
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.Sqlite"))
                       .UseLazyLoadingProxies()),

                "SQLServer" => services.AddDbContextFactory<WeatherDB>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer"))
                       .UseLazyLoadingProxies()),

                "SqlServer" => services.AddDbContextFactory<WeatherDB>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
                            o => o.MigrationsAssembly("WeatherCollector.DAL.Migrations.SqlServer"))
                       .UseLazyLoadingProxies()),

                "" => throw new InvalidOperationException("Тип БД не определён"),
                null => throw new InvalidOperationException("Тип БД не определён"),
                _ => throw new NotSupportedException($"Подключение {Configuration["Database"]} не поддерживается")
            };

        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration) =>
            services
               .AddDatabase(configuration)
               .AddDatabaseFactory(configuration)
               .AddTransient<WeatherDbInitializer>()
               .AddScoped(typeof(IRepository<>), typeof(DbRepository<>))
               .AddScoped(typeof(IRepositoryNamed<>), typeof(DbRepositoryNamed<>))
            ;
    }
}
