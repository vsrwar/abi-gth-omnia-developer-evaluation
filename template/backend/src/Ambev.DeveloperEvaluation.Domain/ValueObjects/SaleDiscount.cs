namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

/// <summary>
/// Represents a sale discount in the system.
/// </summary>
/// <param name="Percentage">Percentage of discount (integer)</param>
/// <param name="Amount">Calculated Amount of discount based on percentage</param>
public record SaleDiscount(int Percentage, decimal Amount);