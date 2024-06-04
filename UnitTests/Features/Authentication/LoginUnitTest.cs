using Api.Features.Authentication;

namespace UnitTests.Features.Authentication;

public class LoginUnitTest
{
    private readonly LoginValidator _validator;

    public LoginUnitTest()
    {
        _validator = new LoginValidator();
    }

    [Fact(DisplayName = "Should Not Have Any Validation Errors")]
    public void Should_Not_Have_Any_Validation_Errors()
    {
        //Arrange
        var faker = new Faker<LoginEntity>().StrictMode(true)
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => setter.Lorem.Text());

        var loginEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(loginEntity);

        //Result
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Should Have Validation Error For Email Empty")]
    public void Should_Have_Validation_Error_For_Email_Empty()
    {
        //Arrange
        var faker = new Faker<LoginEntity>()
            .RuleFor(property => property.Email, setter => null)
            .RuleFor(property => property.Password, setter => setter.Lorem.Text());

        var loginEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(loginEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Email);
    }

    [Fact(DisplayName = "Should Have Validation Error For Password Empty")]
    public void Should_Have_Validation_Error_For_Password_Empty()
    {
        //Arrange
        var faker = new Faker<LoginEntity>()
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => null);

        var loginEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(loginEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Password);
    }
}