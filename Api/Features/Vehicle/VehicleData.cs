using Api.Infrastructure;

namespace Api.Features.Vehicle;

[ExcludeFromCodeCoverage]
public class VehicleData(ParkingDbContext context) : IVehicleData
{
    public async Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync(CancellationToken cancellationToken)
    {
        return await context.Vehicle.ToListAsync(cancellationToken);
    }

    public async Task<VehicleEntity> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await context.Vehicle.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        context.AddAsync(vehicle, cancellationToken);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<VehicleEntity> UpdateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        context.Update(vehicle);
        await context.SaveChangesAsync(cancellationToken);
        return vehicle;
    }

    public async Task<VehicleEntity> DeleteVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        context.Remove(vehicle);
        await context.SaveChangesAsync(cancellationToken);
        return vehicle;
    }
}