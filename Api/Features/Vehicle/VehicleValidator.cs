namespace Api.Features.Vehicle;

public class VehicleValidator : AbstractValidator<VehicleEntity>
{
    public VehicleValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty()
            .WithMessage("Brand cannot be empty");

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model cannot be empty");

        RuleFor(x => x.Plate)
            .NotEmpty()
            .WithMessage("Plate cannot be empty");

        RuleFor(x => x.Color)
            .NotEmpty()
            .WithMessage("Color cannot be empty");

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type cannot be empty");
    }
}