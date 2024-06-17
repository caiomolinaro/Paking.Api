using Api.Features.Authentication;
using Api.Features.Establishment;
using Api.Features.Report;
using Api.Features.Vehicle;
using Api.Infrastructure;

namespace Api.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEstablishmentData, EstablishmentData>();
        services.AddScoped<IVehicleData, VehicleData>();
        services.AddScoped<IAuthenticationData, AuthenticationData>();
        services.AddScoped<IReportData, ReportData>();

        services.AddDbContext<ParkingDbContext>(options =>
            options.UseNpgsql(Environment.GetEnvironmentVariable("MY_DB_CONNECTION_STRING")));

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

                ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
                ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY"))),

                ClockSkew = TimeSpan.Zero
            };
        });

        return services;
    }
}