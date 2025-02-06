using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Services.Discount;

/// <summary>
/// This class has discount formula on Handle method, and is used 
/// to implement chain of responsibility design pattern.
/// <para>Handled by <see cref="DiscountHandler"/></para>
/// </summary>
/// <remarks>See also <see href="https://refactoring.guru/design-patterns/chain-of-responsibility"/></remarks>
public abstract class DiscountCalculator
{
    protected readonly DiscountCalculator? Next;
    
    protected DiscountCalculator(DiscountCalculator? next)
    {
        Next = next;
    }

    /// <summary>
    /// Starts the chain by checking if this instance can handle the discount, or if Next one should be called.
    /// </summary>
    /// <param name="saleProducts">A list of <see cref="SaleProduct"/>.</param>
    /// <returns>A new instance of <see cref="SaleDiscount"/> containing discount value and percentage.</returns>
    /// <returns> Or null if none of the child class can handle discount calculation.</returns>
    public abstract SaleDiscount? Calculate(IEnumerable<SaleProduct> saleProducts);

    /// <summary>
    /// Calculates the discount based on products * quantity * percentage / 100
    /// </summary>
    /// <param name="saleProducts">A list of <see cref="SaleProduct"/>.</param>
    /// <param name="percentage">Percentage to be apllied.</param>
    /// <returns>A new instance of <see cref="SaleDiscount"/> containing discount value and percentage.</returns>
    protected static SaleDiscount Handle(IEnumerable<SaleProduct> saleProducts, int percentage)
    {
        var value = saleProducts.Sum(sp => sp.Quantity * sp.Price) * percentage / 100;
        return new SaleDiscount(percentage, value);
    }
    
    /// <summary>
    /// Checks if this instance of <see cref="DiscountCalculator"/> is able to calculate the discount.
    /// </summary>
    /// <param name="saleProducts">A list of <see cref="SaleProduct"/>.</param>
    /// <returns>True if is the correct instance to apply discount, false otherwise.</returns>
    protected abstract bool CanHandle(IEnumerable<SaleProduct> saleProducts);
}