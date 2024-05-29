using Identity.API.Middleware;
using Identity.Application;
using Identity.Application.Common.Contracts.Services;
using Identity.Infrastructure;
using Identity.Infrastructure.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(name: "v1", new OpenApiInfo() { Title = "Identity.API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Identity.API v1");
        c.RoutePrefix = string.Empty;
    });
}

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (context.Database.IsNpgsql())
        {
            context.Database.Migrate();
        }

        await context.SeedAsync(app.Logger, scope.ServiceProvider.GetRequiredService<IPasswordService>());
    }
    catch (Exception e)
    {
        app.Logger.LogError($"Migrate fail {e}");
    }
}

app.UseAuthorization();
app.MapControllers();
app.UseCustomExceptionHandler();
app.Run();