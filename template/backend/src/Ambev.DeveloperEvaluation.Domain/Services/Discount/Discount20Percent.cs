using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Services.Discount;

/// <summary>
/// Handles if a 20% discount will be applied or not
/// This class belongs to a chain handled in <see cref="DiscountHandler"/>
/// </summary>
internal class Discount20Percent : DiscountCalculator
{
    private const int DiscountPercentage = 20;

    public Discount20Percent(DiscountCalculator? next) : base(next)
    {
    }

    public override SaleDiscount? Calculate(IEnumerable<SaleProduct> saleProducts)
    {
        return CanHandle(saleProducts)
            ? Handle(saleProducts, DiscountPercentage)
            : Next?.Calculate(saleProducts);
    }

    protected override bool CanHandle(IEnumerable<SaleProduct> saleProducts)
    {
        return saleProducts.Any(sp => sp.Quantity is >= 10 and < 20)
               && !saleProducts.Any(sp => sp.Quantity >= 20);
    }
}