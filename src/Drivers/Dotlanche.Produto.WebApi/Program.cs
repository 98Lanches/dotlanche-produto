using Dotlanche.Produto.WebApi.Extensions;
using Dotlanche.Produto.Data.DependencyInjection;
using System.Text.Json.Serialization;
using Dotlanche.Produto.WebApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices(builder.Configuration);
builder.Services.AddPostgresqlDatabase(builder.Configuration);
builder.Services.RunDatabaseMigrations(builder.Configuration);
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services
    .AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new MisconfigurationException("ConnectionStrings:Default"));

var app = builder.Build();

app.MapHealthChecks("/health");

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
