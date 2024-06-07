namespace Api.Features.HealthCheck;

public class HealthCheckEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/healthcheck")
            .WithTags("HealthCheck");

        group.MapGet(string.Empty, GetHealthCheck);
    }

    public static IResult GetHealthCheck()
    {
        string healthCheck = "Ok";

        return Results.Ok(healthCheck);
    }
}