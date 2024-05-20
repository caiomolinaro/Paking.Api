using Api.Infrastructure;

namespace Api.Features.Vehicle;

public class VehicleData : IVehicleData
{
    private readonly ParkingDbContext _context;

    public Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<VehicleEntity> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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