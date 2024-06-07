namespace Api.Features.Authentication;

public class RegisterValidator : AbstractValidator<RegisterEntity>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password cannot be empty")
            .Equal(x => x.Password)
            .WithMessage("Passwords dont match");
    }
}