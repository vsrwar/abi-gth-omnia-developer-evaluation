using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Services.Discount;

/// <summary>
/// Handles if a 10% discount will be applied or not
/// This class belongs to a chain handled in <see cref="DiscountHandler"/>
/// </summary>
internal class Discount10Percent : DiscountCalculator
{
    private const int DiscountPercentage = 10;

    public Discount10Percent(DiscountCalculator? next) : base(next)
    {
    }

    public override SaleDiscount? Calculate(IEnumerable<SaleProduct> saleProducts)
    {
        if (!saleProducts.Any()
            || saleProducts.Sum(sp => sp.Quantity) < 4
            || !saleProducts.Any(sp => sp.Quantity >= 4))
            return null;

        return CanHandle(saleProducts)
            ? Handle(saleProducts, DiscountPercentage)
            : Next?.Calculate(saleProducts);
    }

    protected override bool CanHandle(IEnumerable<SaleProduct> saleProducts)
    {
        return
            saleProducts.Any(sp => sp.Quantity is >= 4 and < 10)
            && !saleProducts.Any(sp => sp.Quantity >= 10);
    }
}