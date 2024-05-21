using Api.Features.Establishment;

namespace Api.Endpoints;

public static class EstablishmentEndpoint
{
    public static void MapEstablishmentEndpoint(this WebApplication app)
    {
        app.MapGet("GetAllEstablishments", async (IEstablishmentData establishmentData, CancellationToken cancellationToken) =>
        {
            var establishments = await establishmentData.GetAllEstablishmentAsync(cancellationToken);
            if (establishments is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(establishments);
        })
           .WithTags(["Establishment"]);

        app.MapPost("/CreateEstablishment", async (IEstablishmentData establishmentData, EstablishmentEntity establishmentEntity,
                                                     CancellationToken cancellationToken) =>
        {
            await establishmentData.CreateEstablishmentAsync(establishmentEntity, cancellationToken);
            return Results.Created("Establishment Created With Success", establishmentEntity);
        })
            .WithTags(["Establishment"]);
    }
}