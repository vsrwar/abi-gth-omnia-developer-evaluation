using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
[Trait("Category", "Sale")]
public class SaleTests
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Fact(DisplayName = "New sale should have status as created")]
    public void Given_NewSale_When_NewSaleCreated_Then_ShouldHaveStatusCreated()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Assert
        Assert.Equal(SaleStatus.Created, sale.Status);
    }

    [Fact(DisplayName = "Cancelled sale should have status as cancelled")]
    public void Given_Sale_When_Cancelled_Then_ShouldHaveStatusCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        //Act
        sale.Cancel();

        // Assert
        Assert.Equal(SaleStatus.Cancelled, sale.Status);
    }

    [Fact(DisplayName = "Should not have discount if sale has less then 4 equal items")]
    public void Given_SaleWithLessThen3EqualProducts_When_DiscountCalculated_Then_ShouldHaveNoDiscount()
    {
        // Arrange
        const int equalProducts = 3;
        var sale = SaleTestData.GenerateValidSaleWithEqualProducts(equalProducts);

        //Act
        sale.CalculateDiscount();

        // Assert
        Assert.Null(sale.Discount);
    }

    [Theory(DisplayName = "Should have 10 percent discount if sale has between 4 and 9 equal items")]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(9)]
    public void Given_SaleWithEqualProductsBetween4And9_When_DiscountCalculated_Then_ShouldHave10PercentDiscount(int equalProducts)
    {
        // Arrange
        const int expectedDiscount = 10;
        var sale = SaleTestData.GenerateValidSaleWithEqualProducts(equalProducts);

        //Act
        sale.CalculateDiscount();

        // Assert
        Assert.NotNull(sale.Discount);
        Assert.Equal(expectedDiscount, sale.Discount.Percentage);
    }

    [Theory(DisplayName = "Should have 20 percent discount if sale has between 10 and 20 equal items")]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    public void Given_SaleWithEqualProductsBetween10And20_When_DiscountCalculated_Then_ShouldHave20PercentDiscount(int equalProducts)
    {
        // Arrange
        const int expectedDiscount = 20;
        var sale = SaleTestData.GenerateValidSaleWithEqualProducts(equalProducts);

        //Act
        sale.CalculateDiscount();

        // Assert
        Assert.NotNull(sale.Discount);
        Assert.Equal(expectedDiscount, sale.Discount.Percentage);
    }

    [Fact(DisplayName = "Should calculate sum of all products")]
    public void Given_SaleProducts_When_CalculateTotalAmount_Then_TotalAmountIsCalculated()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var totalSaleAmount = sale.Products.Sum(x => x.Price * x.Quantity);

        //Act
        sale.CalculateTotalAmount();

        // Assert
        Assert.Equal(totalSaleAmount, sale.TotalAmount);
    }

    [Fact(DisplayName = "Should update sale number")]
    public void Given_Sale_When_UpdateNumber_Then_SaleNumberUpdated()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var currentNumber = sale.Number;
        var newNumber = SaleTestData.GenerateValidSaleNumber();

        //Act
        sale.UpdateNumber(newNumber);

        // Assert
        Assert.Equal(newNumber, sale.Number);
        Assert.NotEqual(currentNumber, sale.Number);
    }
}