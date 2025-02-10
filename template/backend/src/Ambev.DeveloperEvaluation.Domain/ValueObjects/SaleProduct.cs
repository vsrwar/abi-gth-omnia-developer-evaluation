namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

/// <summary>
/// Represents a sale product in the system.
/// </summary>
public class SaleProduct()
{
    /// <summary>
    /// Product unique identifier
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Quantity selected of the same product
    /// </summary>
    public int Quantity { get; set; }
    
    /// <summary>
    /// Current price of product
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Calculated Total by multiplying Price * Quantity
    /// </summary>
    public decimal TotalAmount => Price * Quantity;
}