namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

/// <summary>
/// Represents a sale product in the system.
/// </summary>
/// <param name="ProductId">Product unique identifier</param>
/// <param name="Quantity">Quantity selected of the same product</param>
/// <param name="Price">Current price of product</param>
public record SaleProduct(Guid ProductId, int Quantity, decimal Price)
{
    /// <summary>
    /// Calculated Total by multiplying Price * Quantity
    /// </summary>
    public decimal TotalAmount => Price * Quantity;
}