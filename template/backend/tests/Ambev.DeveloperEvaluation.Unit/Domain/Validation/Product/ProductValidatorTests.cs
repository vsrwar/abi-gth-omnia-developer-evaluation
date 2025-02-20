using Ambev.DeveloperEvaluation.Domain.Validation.Product;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation.Product;

/// <summary>
/// Contains unit tests for the ProductValidator class.
/// Tests cover validation of all user properties including title, price,
/// description, and category requirements.
/// </summary>
[Trait("Category", "ProductValidator")]
public class ProductValidatorTests
{
    private readonly ProductValidator _validator;

    public ProductValidatorTests()
    {
        _validator = new ProductValidator();
    }

    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// This test verifies that a user with valid:
    /// - Title (3-100 characters)
    /// - Price (greater than or equal To 0)
    /// - Description (3-500 characters)
    /// - Image (valid Url format)
    /// - Category (not empty)
    /// passes all validation rules without any errors.
    /// </summary>
    [Fact(DisplayName = "Valid product should pass all validation rules")]
    public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation fails when the title is empty.
    /// </summary>
    [Fact(DisplayName = "Empty title should fail validation")]
    public void Given_EmptyTitle_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = string.Empty;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("The title cannot be empty.");
    }

    /// <summary>
    /// Tests that validation fails when the title is less than 3 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (less than 3 characters) title should fail validation")]
    public void Given_TitleLessThan3Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = "In";

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("Title must be at least 3 characters long.");
    }

    /// <summary>
    /// Tests that validation fails when the title is more than 100 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (more than 100 characters) title should fail validation")]
    public void Given_TitleMoreThan100Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Title = "Invalid".PadLeft(107, 'a');

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Title)
            .WithErrorMessage("Title cannot be longer than 100 characters.");
    }

    /// <summary>
    /// Tests that validation fails when the description is empty.
    /// </summary>
    [Fact(DisplayName = "Empty description should fail validation")]
    public void Given_EmptyDescription_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = string.Empty;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("The description cannot be empty.");
    }

    /// <summary>
    /// Tests that validation fails when the description is less than 3 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (less than 3 characters) description should fail validation")]
    public void Given_DescriptionLessThan3Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = "In";

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("Description must be at least 3 characters long.");
    }

    /// <summary>
    /// Tests that validation fails when the description is more than 500 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (more than 500 characters) description should fail validation")]
    public void Given_DescriptionMoreThan500Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Description = "Invalid".PadLeft(507, 'a');

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Description)
            .WithErrorMessage("Description cannot be longer than 500 characters.");
    }

    /// <summary>
    /// Tests that validation fails when the image is empty.
    /// </summary>
    [Fact(DisplayName = "Empty image should fail validation")]
    public void Given_EmptyImage_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Image = string.Empty;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image)
            .WithErrorMessage("The image location cannot be empty.");
    }

    /// <summary>
    /// Tests that validation fails when the image url is invalid.
    /// </summary>
    [Fact(DisplayName = "Invalid image url should fail validation")]
    public void Given_InvalidImageUrl_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Image = "abc123";

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image)
            .WithErrorMessage("The provided url address is not valid.");
    }

    /// <summary>
    /// Tests that validation fails when the image url is more than 200 characters.
    /// </summary>
    [Fact(DisplayName = "Invalid (more than 200 characters) image url should fail validation")]
    public void Given_ImageMoreThan200Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Image = ProductTestData.GenerateValidImage().PadLeft(207, 'a');

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Image)
            .WithErrorMessage("Image cannot be longer than 200 characters.");
    }

    /// <summary>
    /// Tests that validation fails when the category is empty.
    /// </summary>
    [Fact(DisplayName = "Empty category should fail validation")]
    public void Given_EmptyCategory_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        product.Category = string.Empty;

        // Act
        var result = _validator.TestValidate(product);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Category)
            .WithErrorMessage("The category cannot be empty.");
    }
}