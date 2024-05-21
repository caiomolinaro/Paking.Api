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

    public enum BrandEnum : int
    {
        Toyota,
        Ford,
        BMW,
        Mercedes,
        Yamaha,
        Honda,
        Chevrolet
    }

    public enum ColorEnum : int
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

    public enum TypeEnum : int
    {
        Car,
        Motorcycle
    }
}