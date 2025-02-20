using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
[Trait("Category", "Product")]
public class ProductTests
{
    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid product data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = product.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that product price should not be negative.
    /// </summary>
    [Fact(DisplayName = "Product price should be greater than zero")]
    public void Given_PriceLessThen0_When_UpdatePrice_Then_ShouldThrowException()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        const decimal invalidPrice = -1;

        // Act
        var exception = Assert.Throws<ArgumentException>(() => product.UpdatePrice(invalidPrice));

        // Assert
        Assert.Equal("Price cannot be negative", exception.Message);
    }

    /// <summary>
    /// Tests that updatePrice actually changes products.Price property.
    /// </summary>
    [Fact(DisplayName = "Product price should be updated if price is greater than zero")]
    public void Given_NewPrice_When_UpdatePrice_Then_ShouldProductPriceBeUpdated()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        var currentPrice = product.Price;
        var newPrice = ProductTestData.GenerateValidPrice();

        // Act
        product.UpdatePrice(newPrice);

        // Assert
        Assert.Equal(newPrice, product.Price);
        Assert.NotEqual(currentPrice, product.Price);
    }

    /// <summary>
    /// Tests that product properties are updated.
    /// </summary>
    [Fact(DisplayName = "Product should be updated")]
    public void Given_NewProperties_When_Update_Then_ShouldProductBeUpdated()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();
        var newTitle = ProductTestData.GenerateValidTitle();
        var newDescription = ProductTestData.GenerateValidDescription();
        var newPrice = ProductTestData.GenerateValidPrice();
        var newCategory = ProductTestData.GenerateValidCategory();
        var newImage = ProductTestData.GenerateValidImage();

        var oldTitle = product.Title;
        var oldDescription = product.Description;
        var oldPrice = product.Price;
        var oldCategory = product.Category;
        var oldImage = product.Image;

        // Act
        product.Update(newTitle, newDescription, newPrice, newCategory, newImage);

        // Assert
        Assert.Equal(newTitle, product.Title);
        Assert.NotEqual(oldTitle, product.Title);
        Assert.Equal(newDescription, product.Description);
        Assert.NotEqual(oldDescription, product.Description);
        Assert.Equal(newPrice, product.Price);
        Assert.NotEqual(oldPrice, product.Price);
        Assert.Equal(newCategory, product.Category);
        Assert.NotEqual(oldCategory, product.Category);
        Assert.Equal(newImage, product.Image);
        Assert.NotEqual(oldImage, product.Image);
    }
}