namespace Api.Features.Vehicle;

public interface IVehicleData
{
    Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync(CancellationToken cancellationToken);

    Task<VehicleEntity> GetVehicleByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<VehicleEntity> CreateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken);

    Task<VehicleEntity> UpdateVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken);

    Task<VehicleEntity> DeleteVehicleAsync(VehicleEntity vehicle, CancellationToken cancellationToken);
}