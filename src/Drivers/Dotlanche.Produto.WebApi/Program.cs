using Dotlanche.Produto.WebApi.Extensions;
using Dotlanche.Pagamento.Data.DependencyInjection;
using Dotlanche.Pagamento.WebApi.Exceptions;
using System.Text.Json.Serialization;

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
