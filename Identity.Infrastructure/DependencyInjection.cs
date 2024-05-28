using Identity.Application.Common.Contracts;
using Identity.Infrastructure.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                configuration["DatabaseSettings:ConnectionString"],
                b => b.MigrationsAssembly("Identity.API")
            )
        );

        return services;
    }
}