using Dotlanche.Produto.WebApi.Extensions;
using Dotlanche.Produto.Data.DependencyInjection;
using System.Text.Json.Serialization;

namespace Dotlanche.Produto.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureApplicationServices(builder.Configuration);
        builder.Services.AddPostgresqlDatabase(builder.Configuration);
        builder.Services.RunDatabaseMigrations(builder.Configuration);
        builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapControllers();

        app.Run();
    }
}
