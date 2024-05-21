using Api.Features.Establishment;
using Api.Infrastructure;

namespace Api.Repositories;

public class EstablishmentData(ParkingDbContext _context) : IEstablishmentData
{
    public async Task<IEnumerable<EstablishmentEntity>> GetAllEstablishmentAsync(CancellationToken cancellationToken)
    {
        return await _context.Establishment.ToListAsync(cancellationToken);
    }

    public Task<EstablishmentEntity> GetEstablishmentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<EstablishmentEntity> CreateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        _context.AddAsync(establishment, cancellationToken);
        await _context.SaveChangesAsync();
        return establishment;
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