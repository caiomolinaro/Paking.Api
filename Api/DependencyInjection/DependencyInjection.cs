using Api.Features.Authentication;
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
        services.AddScoped<IAuthenticationData, AuthenticationData>();

        services.AddDbContext<ParkingDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<ParkingDbContext>()
           .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),

                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}