using Api.Features.Vehicle;
using static Api.Features.Vehicle.Enums;

namespace UnitTests.Features.Vehicle;

public class VehicleUnitTest
{
    private readonly VehicleValidator _validator;

    public VehicleUnitTest()
    {
        _validator = new VehicleValidator();
    }

    [Fact(DisplayName = "Should Not Have Any Validation Errors")]
    public void Should_Not_Have_Any_Validation_Errors()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>().StrictMode(true)
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(1, 7))
        .RuleFor(property => property.Model, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Plate, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(1, 10))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(1, 2));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Brand")]
    public void Should_Have_Validation_Error_For_Empty_Brand()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(0))
        .RuleFor(property => property.Model, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Plate, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(1, 10))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(1, 2));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Brand);
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Model")]
    public void Should_Have_Validation_Error_For_Empty_Model()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(1, 7))
        .RuleFor(property => property.Model, setter => null)
        .RuleFor(property => property.Plate, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(1, 10))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(1, 2));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Model);
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Plate")]
    public void Should_Have_Validation_Error_For_Empty_Plate()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(1, 7))
        .RuleFor(property => property.Model, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Plate, setter => null)
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(1, 10))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(1, 2));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Plate);
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Color")]
    public void Should_Have_Validation_Error_For_Empty_Color()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>().StrictMode(true)
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(1, 7))
        .RuleFor(property => property.Model, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Plate, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(0))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(1, 2));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Color);
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Type")]
    public void Should_Have_Validation_Error_For_Empty_Type()
    {
        //Arrange
        var faker = new Faker<VehicleEntity>().StrictMode(true)
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Brand, setter => (BrandEnum)setter.Random.Number(1, 7))
        .RuleFor(property => property.Model, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Plate, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.Color, setter => (ColorEnum)setter.Random.Number(1, 10))
        .RuleFor(property => property.Type, setter => (TypeEnum)setter.Random.Number(0));

        var vehicleEntity = faker.Generate();

        //Act
        var result = _validator.TestValidate(vehicleEntity);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Type);
    }
}