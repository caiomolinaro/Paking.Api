namespace Api.Features.Establishment;

public interface IEstablishmentData
{
    Task<IEnumerable<EstablishmentEntity>> GetAllEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);

    Task<EstablishmentEntity> GetEstablishmentByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<EstablishmentEntity> CreateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);

    Task UpdateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);

    Task DeleteEstablishmentAsync(Guid id, CancellationToken cancellationToken);
}