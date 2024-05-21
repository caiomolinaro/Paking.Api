namespace Api.Features.Establishment;

public class EstablishmentEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CNPJ { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public int CarsVacancies { get; set; }
    public int MotorcycleVacancies { get; set; }
}