using System.Reflection;
using BlogPlatform.Service.Common.Behaviors;
using BlogPlatform.Service.Common.Mappings;
using FluentValidation;
using Identity.Application.Common.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(assembly));
            config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
        });
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}