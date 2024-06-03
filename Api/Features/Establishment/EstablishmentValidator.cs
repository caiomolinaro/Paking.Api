namespace Api.Features.Establishment;

public class EstablishmentValidator : AbstractValidator<EstablishmentEntity>
{
    public EstablishmentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty");

        RuleFor(x => x.CNPJ)
            .NotEmpty()
            .WithMessage("CPNJ cannot be empty")
            .Length(14)
            .WithMessage("CNPJ must be 14 digits");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address cannot be empty");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number cannot be empty")
            .Length(11)
            .WithMessage("Phone number must be 11 digits")
            .Matches("^[0-9]{11}$")
            .WithMessage("Phone number must be only numbers");

        RuleFor(x => x.CarsVacancies)
            .GreaterThan(0)
            .WithMessage("Cars vacancies must be a positive number");

        RuleFor(x => x.MotorcycleVacancies)
            .GreaterThan(0)
            .WithMessage("Motorcycle vacancies must be a positive number");
    }
}