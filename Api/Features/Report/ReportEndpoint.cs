namespace Api.Features.Report;

[ExcludeFromCodeCoverage]
public class ReportEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/reports")
            .WithTags("Reports");

        group.MapGet(string.Empty, GetReport);
    }

    /// <summary>
    /// Returns a report of the total number of registered establishments and vehicles
    /// </summary>

    [Authorize]
    public static async Task<IResult> GetReport(IReportData reportData, CancellationToken cancellationToken)
    {
        var (totalEstablishment, totalVehicle) = await reportData.GetReportAsync(cancellationToken);

        var report = new
        {
            TotalEstablishment = totalEstablishment,
            TotalVehicle = totalVehicle,
        };

        if (report is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(report);
    }
}