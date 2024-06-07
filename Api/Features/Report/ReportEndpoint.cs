namespace Api.Features.Report;

public class ReportEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/reports")
            .WithTags("Reports");

        group.MapGet(string.Empty, GetReport);
    }

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