﻿using Dotlanche.Produto.Application.Ports;
using Dotlanche.Produto.Data.DatabaseContext;
using Dotlanche.Produto.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dotlanche.Produto.Data.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ProdutoDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }

        public static IServiceCollection RunDatabaseMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            using (var sp = services.BuildServiceProvider())
            {
                using var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("Produto.Data.DependencyInjection");

                using var scope = sp.CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>();

                _ = bool.TryParse(configuration.GetSection("RunMigrationsOnStartup").Value,
                    out var shouldRunMigrationsOnStartup);

                if (shouldRunMigrationsOnStartup)
                {
                    try
                    {
                        db.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        logger.LogWarning(e, "Could not run Migrations on startup");
                    }
                }
            }

            return services;
        }
    }
}