using Api.Features.Establishment;

namespace Api.Endpoints;

public static class EstablishmentEndpoint
{
    public static void MapEstablishmentEndpoint(this WebApplication app)
    {
        app.MapGet("GetEstablishmentById/{id:guid}", async ([FromRoute] Guid id, IEstablishmentData establishmentData, CancellationToken cancellationToken) =>
        {
            var establishmentById = await establishmentData.GetEstablishmentByIdAsync(id, cancellationToken);
            if (establishmentById is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(establishmentById);
        }).WithTags(["Establishment"]);

        app.MapGet("GetAllEstablishments", async (IEstablishmentData establishmentData, CancellationToken cancellationToken) =>
        {
            var establishments = await establishmentData.GetAllEstablishmentAsync(cancellationToken);
            if (establishments is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(establishments);
        }).WithTags(["Establishment"]);

        app.MapPost("/CreateEstablishment", async (IEstablishmentData establishmentData, EstablishmentEntity establishmentEntity, CancellationToken cancellationToken) =>
        {
            await establishmentData.CreateEstablishmentAsync(establishmentEntity, cancellationToken);
            return Results.Created("Establishment Created With Success", establishmentEntity);
        }).WithTags(["Establishment"]);

        app.MapPut("/UpdateEstablishment", async (IEstablishmentData establishmentData, EstablishmentEntity establishmentEntity, CancellationToken cancellationToken) =>
        {
            if (establishmentEntity is null)
            {
                return Results.NotFound();
            }

            await establishmentData.UpdateEstablishmentAsync(establishmentEntity, cancellationToken);
            return Results.Ok(establishmentEntity);
        }).WithTags(["Establishment"]);

        app.MapDelete("DeleteEstablishment/{id:guid}", async ([FromRoute] Guid id, IEstablishmentData establishmentData, CancellationToken cancellationToken) =>
        {
            var entityById = await establishmentData.GetEstablishmentByIdAsync(id, cancellationToken);
            if (entityById is null)
            {
                return Results.NotFound();
            }

            await establishmentData.DeleteEstablishmentAsync(entityById, cancellationToken);
            return Results.NoContent();
        }).WithTags(["Establishment"]);
    }
}