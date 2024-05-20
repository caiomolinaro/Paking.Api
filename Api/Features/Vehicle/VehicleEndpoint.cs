namespace Api.Features.Vehicle;

public static class VehicleEndpoint
{
    public static void MapVehicleEndpoint(this WebApplication app)
    {
        app.MapGet("/vehicle", () => "Hello World")
           .WithTags(new[] { "Vehicle" });
    }
}