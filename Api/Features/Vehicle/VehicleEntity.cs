namespace Api.Features.Vehicle;

public class VehicleEntity
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public BrandEnum Brand { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public string? Model { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public string? Plate { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public ColorEnum Color { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public TypeEnum Type { get; set; }

    public enum BrandEnum
    {
        Toyota,
        Ford,
        BMW,
        Mercedes,
        Yamaha,
        Honda,
        Chevrolet
    }

    public enum ColorEnum
    {
        Red,
        Blue,
        Yellow,
        Green,
        Orange,
        Purple,
        Pink,
        Brown,
        Gray,
        Black,
    }

    public enum TypeEnum
    {
        Car,
        Motorcycle
    }
}