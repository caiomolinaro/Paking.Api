using Api.Features.Establishment;

namespace UnitTests.Features.Establishment;

public class EstablishmentUnitTest
{
    private readonly EstablishmentValidator _validator;

    public EstablishmentUnitTest()
    {
        _validator = new EstablishmentValidator();
    }

    [Fact(DisplayName = "Should Not Have Any Validation Errors")]
    public void Should_Not_Have_Any_Validation_Errors()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>().StrictMode(true)
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => setter.Company.Random.ToString())
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Name")]
    public void Should_Have_Validation_Error_For_Empty_Name()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => string.Empty)
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Name);
    }

    [Fact(DisplayName = "Should Have Validation Error For CNPJ is not 14 Digits")]
    public void Should_Have_Validation_Error_For_CNPJ_is_not_14_Digits()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => setter.Company.Random.ToString())
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("#############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.CNPJ);
    }

    [Fact(DisplayName = "Should Have Validation Error For CNPJ")]
    public void Should_Have_Validation_Error_For_Empty_CNPJ()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => setter.Company.Random.ToString())
        .RuleFor(property => property.CNPJ, setter => string.Empty)
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.CNPJ);
    }

    [Fact(DisplayName = "Should Have Validation Error For Empty Adrress")]
    public void Should_Have_Validation_Error_For_Empty_Address()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => string.Empty)
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => string.Empty)
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.Address);
    }

    [Fact(DisplayName = "Should Have Validation Error Phone Number")]
    public void Should_Have_Validation_Error_For_Empty_Phone_Number()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => string.Empty)
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => string.Empty)
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.PhoneNumber);
    }

    [Fact(DisplayName = "Should Have Validation Error For Phone Number is Not 11 Digits")]
    public void Should_Have_Validation_Error_For_Phone_Number_is_Not_11_Digits()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => string.Empty)
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("#####"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.PhoneNumber);
    }

    [Fact(DisplayName = "Should Have Validation Error For Phone Number is Just Numbers")]
    public void Should_Have_Validation_Error_For_Phone_Number_is_Just_Numbers()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => string.Empty)
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Lorem.Random.ToString())
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.PhoneNumber);
    }

    [Fact(DisplayName = "Should Have Validation Error For Cars Quantity Bellow Zero")]
    public void Should_Have_Validation_Error_For_Cars_Quantity_Bellow_Zero()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
        .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => setter.Company.Random.ToString())
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(-1, -1))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(1, 100));

        var establishment = faker.Generate();
        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.CarsVacancies);
    }

    [Fact(DisplayName = "Should Have Validation Error For Motorcycle Bellow Zero")]
    public void Should_Have_Validation_Error_For_Motorcycle_Quantity_Bellow_Zero()
    {
        //Arrange
        var faker = new Faker<EstablishmentEntity>()
       .RuleFor(property => property.Id, setter => Guid.NewGuid())
        .RuleFor(property => property.Name, setter => setter.Company.Random.ToString())
        .RuleFor(property => property.CNPJ, setter => setter.Random.ReplaceNumbers("##############"))
        .RuleFor(property => property.Address, setter => setter.Address.Random.ToString())
        .RuleFor(property => property.PhoneNumber, setter => setter.Random.ReplaceNumbers("###########"))
        .RuleFor(property => property.CarsVacancies, setter => setter.Random.Number(1, 100))
        .RuleFor(property => property.MotorcycleVacancies, setter => setter.Random.Number(-1, -1));

        var establishment = faker.Generate();

        //Act
        var result = _validator.TestValidate(establishment);

        //Result
        result.ShouldHaveValidationErrorFor(property => property.MotorcycleVacancies);
    }
}