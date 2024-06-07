namespace Api.Features.Establishment;

[ExcludeFromCodeCoverage]
public class EstablishmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/establishments")
            .WithTags("Establishments");

        group.MapGet(string.Empty, GetAllEstablishments);
        group.MapGet("/{id:guid}", GetEstablishmentById);
        group.MapPost(string.Empty, CreateEstablishment);
        group.MapPut(string.Empty, UpdateEstablishment);
        group.MapDelete("/{id:guid}", DeleteEstablishment);
    }

    [Authorize]
    public static async Task<IResult> GetAllEstablishments(IEstablishmentData establishmentData, CancellationToken cancellationToken)
    {
        var establishments = await establishmentData.GetAllEstablishmentAsync(cancellationToken);
        if (establishments is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(establishments);
    }

    [Authorize]
    public static async Task<IResult> GetEstablishmentById([FromRoute] Guid id, IEstablishmentData establishmentData, CancellationToken cancellationToken)
    {
        var establishmentById = await establishmentData.GetEstablishmentByIdAsync(id, cancellationToken);

        if (establishmentById is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(establishmentById);
    }

    [Authorize]
    public static async Task<IResult> CreateEstablishment(IEstablishmentData establishmentData, IValidator<EstablishmentEntity> validator, EstablishmentEntity establishmentEntity, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(establishmentEntity, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        await establishmentData.CreateEstablishmentAsync(establishmentEntity, cancellationToken);

        return Results.Created($"/establishments/{establishmentEntity.Id}", establishmentEntity);
    }

    [Authorize]
    public static async Task<IResult> UpdateEstablishment(IEstablishmentData establishmentData, EstablishmentEntity establishmentEntity, IValidator<EstablishmentEntity> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(establishmentEntity, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        if (establishmentEntity is null)
        {
            return Results.NotFound();
        }

        await establishmentData.UpdateEstablishmentAsync(establishmentEntity, cancellationToken);

        return Results.Ok(establishmentEntity);
    }

    [Authorize]
    public static async Task<IResult> DeleteEstablishment([FromRoute] Guid id, IEstablishmentData establishmentData, CancellationToken cancellationToken)
    {
        var entityById = await establishmentData.GetEstablishmentByIdAsync(id, cancellationToken);
        if (entityById is null)
        {
            return Results.NotFound();
        }

        await establishmentData.DeleteEstablishmentAsync(entityById, cancellationToken);

        return Results.NoContent();
    }
}