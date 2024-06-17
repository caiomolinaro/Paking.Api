using Api.Features.Authentication;

namespace UnitTests.Features.Authentication;

public class RegisterUnitTest
{
    private readonly RegisterValidator _validator;

    public RegisterUnitTest()
    {
        _validator = new RegisterValidator();
    }

    private readonly string password = "password";

    [Fact(DisplayName = "Should Not Have Any Validation Errors")]
    public void Should_Not_Have_Any_Validation_Errors()
    {
        //Arrange
        var faker = new Faker<RegisterEntity>().StrictMode(true)
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => password)
            .RuleFor(property => property.ConfirmPassword, setter => password);

        var registerEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(registerEntity);

        //Result
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Should Have Validation Error For Email Empty")]
    public void Should_Have_Validation_Error_For_Email_Empty()
    {
        //Arrange
        var faker = new Faker<RegisterEntity>()
            .RuleFor(property => property.Email, setter => null)
            .RuleFor(property => property.Password, setter => password)
            .RuleFor(property => property.ConfirmPassword, setter => password);

        var registerEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(registerEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Email);
    }

    [Fact(DisplayName = "Should Have Validation Error For Password Empty")]
    public void Should_Have_Validation_Error_For_Password_Empty()
    {
        //Arrange
        var faker = new Faker<RegisterEntity>().StrictMode(true)
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => null)
            .RuleFor(property => property.ConfirmPassword, setter => password);

        var registerEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(registerEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Password);
    }

    [Fact(DisplayName = "Should Have Validation Error For Confirm Password Empty")]
    public void Should_Have_Validation_Error_For_Confirm_Password_Empty()
    {
        //Arrange
        var faker = new Faker<RegisterEntity>().StrictMode(true)
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => password)
            .RuleFor(property => property.ConfirmPassword, setter => null);

        var registerEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(registerEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.ConfirmPassword);
    }

    [Fact(DisplayName = "Should Have Validation Error For Confirm Password Dont Match With Password")]
    public void Should_Have_Validation_Error_For_Confirm_Password_Dont_Match_With_Password()
    {
        //Arrange
        //Arrange
        var faker = new Faker<RegisterEntity>().StrictMode(true)
            .RuleFor(property => property.Email, setter => setter.Person.Email.ToString())
            .RuleFor(property => property.Password, setter => password)
            .RuleFor(property => property.ConfirmPassword, setter => setter.Lorem.Text());

        var registerEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(registerEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.ConfirmPassword);
    }
}