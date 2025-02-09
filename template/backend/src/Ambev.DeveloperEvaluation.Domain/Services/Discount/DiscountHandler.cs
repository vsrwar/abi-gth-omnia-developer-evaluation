using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Services.Discount;

/// <summary>
/// Handles and starts the DiscountCalculator chain.
/// </summary>
/// <remarks>See also <see href="https://refactoring.guru/design-patterns/chain-of-responsibility"/></remarks>
public static class DiscountHandler
{
    /// <summary>
    /// Creates chain by instantiating and referencing in the correct order.
    /// </summary>
    /// <param name="saleProducts">A list of <see cref="SaleProduct"/>.</param>
    /// <returns>A new instance of <see cref="SaleDiscount"/> containing discount value and percentage.</returns>
    /// <returns> Or null if none of the child class can handle discount calculation.</returns>
    public static SaleDiscount? Calculate(IEnumerable<SaleProduct> saleProducts)
    {
        var discount20 = new Discount20Percent(null);
        var discount10 = new Discount10Percent(discount20);
        
        return discount10.Calculate(saleProducts);
    }
}