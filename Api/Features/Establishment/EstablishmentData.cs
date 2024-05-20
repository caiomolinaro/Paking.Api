using Api.Features.Establishment;
using Api.Infrastructure;

namespace Api.Repositories;

public class EstablishmentData : IEstablishmentData
{
    private readonly ParkingDbContext _context;

    public Task<IEnumerable<EstablishmentEntity>> GetAllEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<EstablishmentEntity> GetEstablishmentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<EstablishmentEntity> CreateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEstablishmentAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}