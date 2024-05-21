using Api.Features.Establishment;
using Api.Features.Vehicle;
using Api.Infrastructure;

namespace Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEstablishmentData, EstablishmentData>();
        services.AddScoped<IVehicleData, VehicleData>();

        services.AddDbContext<ParkingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        return services;
    }
}