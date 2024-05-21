using Api.Infrastructure;

namespace Api.Features.Vehicle;

public class VehicleData(ParkingDbContext context) : IVehicleData
{
    public async Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync(CancellationToken cancellationToken)
    {
        return await context.Vehicle.ToListAsync(cancellationToken);
    }

    public Task<VehicleEntity> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        context.AddAsync(vehicle, cancellationToken);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public Task UpdateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteVehicleAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}