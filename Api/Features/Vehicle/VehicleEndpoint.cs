namespace Api.Features.Vehicle;

[ExcludeFromCodeCoverage]
public class VehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/vehicles")
            .WithTags("Vehicles");

        group.MapGet(string.Empty, GetAllVehicles);
        group.MapGet("/{id:guid}", GetVehicleById);
        group.MapPost(string.Empty, CreateVehicle);
        group.MapPut(string.Empty, UpdateVehicle);
        group.MapDelete("/{id:guid}", DeleteVehicle);
    }

    [Authorize]
    public static async Task<IResult> GetAllVehicles(IVehicleData vehicleData, CancellationToken cancellationToken)
    {
        var vehicles = await vehicleData.GetAllVehiclesAsync(cancellationToken);
        if (vehicles is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(vehicles);
    }

    [Authorize]
    public static async Task<IResult> GetVehicleById([FromRoute] Guid id, IVehicleData vehicleData, CancellationToken cancellationToken)
    {
        var vehicleById = await vehicleData.GetVehicleByIdAsync(id, cancellationToken);

        if (vehicleById is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(vehicleById);
    }

    [Authorize]
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

    [Authorize]
    public static async Task<IResult> UpdateVehicle(IVehicleData vehicleData, VehicleEntity vehicleEntity, IValidator<VehicleEntity> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(vehicleEntity, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        if (vehicleEntity is null)
        {
            return Results.NotFound();
        }

        await vehicleData.UpdateVehicleAsync(vehicleEntity, cancellationToken);

        return Results.Ok(vehicleEntity);
    }

    [Authorize]
    public static async Task<IResult> DeleteVehicle([FromRoute] Guid id, IVehicleData vehicleData, CancellationToken cancellationToken)
    {
        var entityById = await vehicleData.GetVehicleByIdAsync(id, cancellationToken);
        if (entityById is null)
        {
            return Results.NotFound();
        }

        await vehicleData.DeleteVehicleAsync(entityById, cancellationToken);

        return Results.NoContent();
    }
}