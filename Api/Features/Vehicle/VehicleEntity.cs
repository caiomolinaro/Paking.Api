using static Api.Features.Vehicle.Enums;

namespace Api.Features.Vehicle;

public class VehicleEntity
{
    public Guid Id { get; set; }
    public BrandEnum Brand { get; set; }
    public string? Model { get; set; }
    public string? Plate { get; set; }
    public ColorEnum Color { get; set; }
    public TypeEnum Type { get; set; }
}