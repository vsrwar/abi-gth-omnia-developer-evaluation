using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation.Sale;

/// <summary>
/// Contains unit tests for the SaleValidator class.
/// Tests cover validation of all sale properties including title, price,
/// description, and category requirements.
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid sale should pass all validation rules")]
    public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails when the userId is empty.
    /// </summary>
    [Fact(DisplayName = "Empty userId should fail validation")]
    public void Given_EmptyUserId_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateEmptyUserIdSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserId)
            .WithErrorMessage("UserId cannot be empty.");
    }

    /// <summary>
    /// Tests that validation fails when the products are empty.
    /// </summary>
    [Fact(DisplayName = "Empty products should fail validation")]
    public void Given_EmptyProducts_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = SaleTestData.GenerateSaleWithNoProducts();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Products)
            .WithErrorMessage("Products must have at least one product.");
    }

    /// <summary>
    /// Tests that a sale with above 20 equal products should fail.
    /// </summary>
    [Fact(DisplayName = "Should not be possible to create a sale with above 20 equal products")]
    public void Given_SaleWith20EqualProducts_When_Create_Then_ThrowError()
    {
        // Arrange
        const int equalProducts = 21;
        var sale = SaleTestData.GenerateValidSaleWithEqualProducts(equalProducts);

        //Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Products)
            .WithErrorMessage("It's not possible to sell above 20 identical items.");
    }

    /// <summary>
    /// Tests that validation fails when the branch is empty.
    /// </summary>
    [Fact(DisplayName = "Empty branch should fail validation")]
    public void Given_EmptyBranch_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateBranchSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch)
            .WithErrorMessage("Branch cannot be empty.");
    }

    /// <summary>
    /// Tests that validation fails when the branch is less than 3 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (less than 3 characters) branch should fail validation")]
    public void Given_BranchLessThan3Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        const int charsLength = 2;
        var sale = SaleTestData.GenerateBranchSale(charsLength);

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch)
            .WithErrorMessage("Branch must be at least 3 characters long.");
    }

    /// <summary>
    /// Tests that validation fails when the branch is more than 100 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (more than 100 characters) branch should fail validation")]
    public void Given_BranchMoreThan100Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        const int charsLength = 107;
        var sale = SaleTestData.GenerateBranchSale(charsLength);

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Branch)
            .WithErrorMessage("Branch must be no more than 100 characters.");
    }

}