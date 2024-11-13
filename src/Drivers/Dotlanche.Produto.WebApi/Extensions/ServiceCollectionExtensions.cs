using Dotlanche.Produto.Application.UseCases;
using DotLanches.Application.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Dotlanche.Produto.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.ConfigureSwagger();
        services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "DotLanches.Produto API",
                Description = "Backend de gestão de produtos 98Lanches"
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        return services;
    }
}
