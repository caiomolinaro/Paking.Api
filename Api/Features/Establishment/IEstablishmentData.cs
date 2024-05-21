namespace Api.Features.Establishment;

public interface IEstablishmentData
{
    Task<IEnumerable<EstablishmentEntity>> GetAllEstablishmentAsync(CancellationToken cancellationToken);

    Task<EstablishmentEntity> GetEstablishmentByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<EstablishmentEntity> CreateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);

    Task<EstablishmentEntity> UpdateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);

    Task<EstablishmentEntity> DeleteEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken);
}