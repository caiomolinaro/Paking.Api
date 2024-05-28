namespace Api.Features.Report;

public interface IReportData
{
    Task<(int totalEstablishment, int totalVehicle)> GetReportAsync(CancellationToken cancellationToken);
}