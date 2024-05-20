namespace Api.Endpoints;

public static class EstablishmentEndpoint
{
    public static void MapEstablishmentEndpoint(this WebApplication app)
    {
        app.MapGet("/establishment", () => "Hello World")
           .WithTags(new[] { "Establishment" });
    }
}