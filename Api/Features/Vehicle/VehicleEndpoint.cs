namespace Api.Features.Vehicle;

public static class VehicleEndpoint
{
    public static void MapVehicleEndpoint(this WebApplication app)
    {
        app.MapGet("GetAllVehicles", async (IVehicleData vehicleData, CancellationToken cancellationToken) =>
        {
            var vehicles = await vehicleData.GetAllVehiclesAsync(cancellationToken);
            if (vehicles is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(vehicles);
        })
            .WithDescription("Return all vehicles")
            .WithTags(["Vehicle"]);

        app.MapPost("/CreateVehicle", async (IVehicleData vehicleData, VehicleEntity vehicleEntity, CancellationToken cancellationToken) =>
        {
            await vehicleData.CreateVehicleAsync(vehicleEntity, cancellationToken);
            return Results.Created("Vehicle Created With Success", vehicleEntity);
        })
            .WithTags(["Vehicle"]);
    }
}