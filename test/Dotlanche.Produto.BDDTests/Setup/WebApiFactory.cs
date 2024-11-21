using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dotlanche.Produto.Data.DatabaseContext;
using Dotlanche.Produto.Application.Ports;
using Dotlanche.Produto.Data.Repositories;
using Dotlanche.Produto.WebApi;
using DotLanche.Produto.Domain.Entities;

namespace Dotlanche.Produto.BDDTests.Setup
{
    public class ProdutoApi : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                SetupInMemoryDatabase(services);
            });
            builder.ConfigureAppConfiguration(cfgBuilder =>
            {
                cfgBuilder.AddEnvironmentVariables();

                var appsettingsFilePath = Path.Combine(Environment.CurrentDirectory, "appsettings.bdd.json");
                cfgBuilder.AddJsonFile(appsettingsFilePath);
            });

            builder.UseEnvironment("Development");
        }

        private static IServiceCollection SetupInMemoryDatabase(IServiceCollection services)
        {
            var dbContextDescriptor = services.Single(
                d => d.ServiceType ==
                    typeof(DbContextOptions<ProdutoDbContext>));

            services.Remove(dbContextDescriptor);

            // In memory database to simplify test run on CI
            services.AddDbContextPool<ProdutoDbContext>(options =>
                options.UseInMemoryDatabase("Produto"));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            // Build the service provider to resolve the context and apply migrations
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoDbContext>();
                dbContext.Database.EnsureCreated(); // Ensures database schema is created
                SeedDatabase(dbContext); // Apply seed data
            }

            return services;
        }

        // Seed the in-memory database
        private static void SeedDatabase(ProdutoDbContext dbContext)
        {
            if (!dbContext.Categoria.Any())
            {
                dbContext.Categoria.AddRange(
                    new Categoria { Id = 1, Name = "Lanche" },
                    new Categoria { Id = 2, Name = "Acompanhamento" },
                    new Categoria { Id = 3, Name = "Bebida" },
                    new Categoria { Id = 4, Name = "Sobremesa" }
                );
                dbContext.SaveChanges();
            }
        }
    }
}