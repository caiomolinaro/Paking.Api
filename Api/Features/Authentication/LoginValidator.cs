namespace Api.Features.Authentication;

public class LoginValidator : AbstractValidator<LoginEntity>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty");
    }
}