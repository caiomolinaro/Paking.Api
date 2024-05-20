namespace Api.Features.Establishment;

public class EstablishmentEntity
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public string? CNPJ { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "Phone number must be 11 digits")]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "Phone number must be only numbers")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Just interger numbers")]
    public int CarsVacancies { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Just interger numbers")]
    public int MotorcycleVacancies { get; set; }
}