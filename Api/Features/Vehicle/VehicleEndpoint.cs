namespace Api.Features.Vehicle;

public class VehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/vehicles")
            .WithTags("Vehicles");

        group.MapGet(string.Empty, GetAllVehicles);
        group.MapPost(string.Empty, CreateVehicle);
    }

    public static async Task<IResult> GetAllVehicles(IVehicleData vehicleData, CancellationToken cancellationToken)
    {
        var vehicles = await vehicleData.GetAllVehiclesAsync(cancellationToken);
        if (vehicles is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(vehicles);
    }

    public static async Task<IResult> CreateVehicle(IVehicleData vehicleData, VehicleEntity vehicleEntity, IValidator<VehicleEntity> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(vehicleEntity, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        await vehicleData.CreateVehicleAsync(vehicleEntity, cancellationToken);

        return Results.Created($"/vehicles/{vehicleEntity.Id}", vehicleEntity);
    }
}