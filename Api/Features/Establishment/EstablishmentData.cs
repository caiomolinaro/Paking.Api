using Api.Infrastructure;

namespace Api.Features.Establishment;

[ExcludeFromCodeCoverage]
public class EstablishmentData(ParkingDbContext context) : IEstablishmentData
{
    public async Task<IEnumerable<EstablishmentEntity>> GetAllEstablishmentAsync(CancellationToken cancellationToken)
    {
        return await context.Establishment.ToListAsync(cancellationToken);
    }

    public async Task<EstablishmentEntity> GetEstablishmentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Establishment.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<EstablishmentEntity> CreateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        context.AddAsync(establishment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return establishment;
    }

    public async Task<EstablishmentEntity> UpdateEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        context.Update(establishment);
        await context.SaveChangesAsync(cancellationToken);
        return establishment;
    }

    public async Task<EstablishmentEntity> DeleteEstablishmentAsync(EstablishmentEntity establishment, CancellationToken cancellationToken)
    {
        context.Remove(establishment);
        await context.SaveChangesAsync(cancellationToken);
        return establishment;
    }
}