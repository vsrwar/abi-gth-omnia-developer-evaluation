namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the customer's unique identifier.
    /// Must not be null or empty
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Gets or sets a list of products, containing ids and quantities
    /// </summary>
    public IEnumerable<SaleProductRequest> Products { get; set; }

    /// <summary>
    /// Gets or sets branch where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;
}