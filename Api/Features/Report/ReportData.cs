using Api.Infrastructure;
using static Api.Features.Vehicle.Enums;

namespace Api.Features.Report;

[ExcludeFromCodeCoverage]
public class ReportData(ParkingDbContext context) : IReportData
{
    public async Task<(int totalEstablishment, int totalVehicle)> GetReportAsync(CancellationToken cancellationToken)
    {
        var typeValue = TypeEnum.Car.ToString();

        int totalEstablishment = await context.Establishment.CountAsync(cancellationToken);
        int totalVehicle = await context.Vehicle.CountAsync(cancellationToken);

        return (totalEstablishment, totalVehicle);
    }
}