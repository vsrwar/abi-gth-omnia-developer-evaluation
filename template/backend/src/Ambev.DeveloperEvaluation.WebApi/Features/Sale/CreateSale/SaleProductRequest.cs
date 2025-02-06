namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Represents a sale product request in the system.
/// </summary>
/// <param name="ProductId">Product unique identifier</param>
/// <param name="Quantity">Quantity selected of the same product</param>
public record SaleProductRequest(Guid ProductId, int Quantity);