using Api.Application.Services;
using Api.Infrastructure.Repositories;

namespace Api;

public static class ServiceCollectionExtions
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services
            .AddApplication()
            .AddInfrastructure()
            .AddMediatr();

        return services;
    }

    private static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductoService, ProductoService>();
        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductoRepository, ProductoRepository>();
        return services;
    }

    private static IServiceCollection AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
        return services;
    }
}
